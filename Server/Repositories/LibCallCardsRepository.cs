using Microsoft.EntityFrameworkCore;
using Server.Helpers.Exceptions;
using Server.Models;

namespace Server.Repositories
{
    public class LibCallCardsRepository : ILibCallCardsRepository
    {
        private readonly LibraryManagementContext _context;

        public LibCallCardsRepository(LibraryManagementContext context)
        {
            _context = context;
        }

        public async Task<List<LibCallCard>> GetCallCardsAsync()
        {
            var callCards = await _context.LibCallCards.ToListAsync();
            return callCards;
        }

        public async Task<LibCallCard> GetCallCardByIdAsync(string callCardId)
        {
            var callCard = await _context.LibCallCards.FirstOrDefaultAsync(x => x.CallCardId == callCardId);
            if (callCard == null) throw new NonExistenceException(string.Format("Call card {0} is not found", callCardId));
            return callCard;
        }

        public async Task<LibCallCard> GetCallCardByBookIdAsync(string bookId)
        {
            var callCard = await _context.LibCallCards.FirstOrDefaultAsync(x => x.BookId == bookId);
            if (callCard == null) throw new NonExistenceException(string.Format("Call card for book {0} is not found", bookId));
            return callCard;
        }

        public async Task<string> CreateCallCardAsync(LibCallCard callCardToCreate)
        {
            var book = await _context.LibBooks.FirstOrDefaultAsync(x => x.BookId == callCardToCreate.BookId);
            if (book == null) throw new NonExistenceException(string.Format("Book {0} is not found", callCardToCreate.BookId));

            var membership = await _context.LibMemberships.FirstOrDefaultAsync(x => x.MembershipId == callCardToCreate.MembershipId);
            if (membership == null)
                throw new NonExistenceException(
                    string.Format("Membership {0} is not found", callCardToCreate.MembershipId));

            // Check valid membership
            if (membership.Status == 1)
                throw new ExpiredMembershipException(
                    string.Format("Cannot create call card for membership {0} due to membership has expired", callCardToCreate.MembershipId));

            // Check available book
            if (book.Status == 1)
                throw new UnavailableBookException(
                    string.Format("Cannot create call card for membership {0} due to book {1} is unavaible",
                    callCardToCreate.MembershipId, callCardToCreate.BookId));

            // Check due call card
            var query1 = from cCallCard in _context.LibCallCards
                         join cMembership in _context.LibMemberships on cCallCard.MembershipId equals cMembership.MembershipId
                         where cCallCard.Status == 2 && cMembership.MembershipId == membership.MembershipId
                         select cCallCard;

            var callCards = await query1.ToListAsync();
            if (callCards.Count > 0)
                throw new DueCallCardException(
                    string.Format("Cannot create call card for membership {0} due to membership has due call card(s)", membership.MembershipId));

            // Check if membership is borrowing more than 5 books in 4 days
            var query2 = from cCallCard in _context.LibCallCards
                         join cMembership in _context.LibMemberships on cCallCard.MembershipId equals cMembership.MembershipId
                         where cCallCard.Status != 1 && cMembership.MembershipId == membership.MembershipId
                         select cCallCard;

            callCards = await query2.ToListAsync();
            int count = 0;
            foreach (var callCard in callCards)
                if ((DateTime.Now - callCard.CreatedDate.Value).Days <= 4) count++;

            if (count > 4)
                throw new InvalidOperationException(
                    string.Format("Cannot create call card for membership {0} due to membership borrowing more than 5 books in 4 days", membership.MembershipId));

            // Check if due date > created date
            if (callCardToCreate.DueDate <= callCardToCreate.CreatedDate) 
                throw new InvalidOperationException("Cannot create call card since due date must be after created date");

            // Create call card
            book.Status = 1;
            _context.LibCallCards.Add(callCardToCreate);
            await _context.SaveChangesAsync();
            return callCardToCreate.CallCardId;
        }

        //public async void UpdateAllCallCardsStatusesAsync()
        //{
        //    var query = from callCard in _context.LibCallCards
        //                where callCard.CreatedDate >= callCard.DueDate
        //                select callCard;

        //    var callCards = await query.ToListAsync();
        //    foreach (var callCard in callCards) callCard.Status = 2;
        //    await _context.SaveChangesAsync();
        //}

        public async Task<string> UpdateCallCardStatusAsync(string callCardId, int status)
        {
            var callCard = await _context.LibCallCards.FirstOrDefaultAsync(x => x.CallCardId == callCardId);
            if (callCard == null) throw new NonExistenceException(string.Format("Call card {0} is not found", callCardId));

            var book = await _context.LibBooks.FirstOrDefaultAsync(x => x.BookId == callCard.BookId);
            if (book == null) throw new NonExistenceException(string.Format("Call card for book {0} is not found", callCard.BookId));

            switch (status)
            {
                case 0:
                    book.Status = 1;
                    break;
                case 1:
                    book.Status = 0;
                    break;
                case 2:
                    // Does not allow to mark as due if book was already returned 
                    if (book.Status == 0)
                        throw new InvalidOperationException
                            (string.Format("Book {0} in call card {1} was already returned", book.BookId, callCardId));

                    // Does not allow to mark as due if due date is not met
                    if (DateTime.Now <= callCard.DueDate)
                        throw new InvalidOperationException
                            (string.Format("Call card {0}'s due date is not met", callCardId));

                    book.Status = 1;
                    break;
                case 3:
                    // Does not allow to mark as lost if book was already returned 
                    if (book.Status == 0)
                        throw new InvalidOperationException
                            (string.Format("Book {0} in call card {1} was already returned", book.BookId, callCardId));

                    book.Status = 1;
                    break;
            }

            callCard.Status = status;
            await _context.SaveChangesAsync();
            return callCardId;
        }
    }
}
