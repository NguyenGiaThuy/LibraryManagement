using Microsoft.EntityFrameworkCore;
using Server.Helpers;
using Server.Models;

namespace Server.Repositories
{
    public class LibCallCardsRepository : ILibCallCardsRepository
    {
        internal static AsyncEvent<EventArgs> OnStatusChangedAsync;

        private readonly LibraryManagementContext _context;

        public LibCallCardsRepository(LibraryManagementContext context)
        {
            _context = context;
        }

        public async Task<List<LibCallCard>> GetCallCardsAsync()
        {
            var result = await _context.LibCallCards.ToListAsync();
            return result;
        }

        public async Task<List<LibCallCard>> GetCallCardsByIsbnAsync(string isbn)
        {
            var result = await _context.LibCallCards.Where(x => x.Isbn == isbn).ToListAsync();
            if (result == null) throw new NonExistenceException(String.Format("Call card with isbn {0} not found", isbn));
            return result;
        }

        public async Task<List<LibCallCard>> GetCallCardsByMembershipIdAsync(string membershipId)
        {
            var result = await _context.LibCallCards.Where(x => x.MembershipId == membershipId).ToListAsync();
            if (result == null) throw new NonExistenceException(String.Format("Call card with membership {0} not found", membershipId));
            return result;
        }

        public async Task<LibCallCard> GetCallCardByIdAsync(string callCardId)
        {
            var result = await _context.LibCallCards.FirstOrDefaultAsync(x => x.CallCardId == callCardId);
            if (result == null) throw new NonExistenceException(String.Format("Call card {0} not found", callCardId));
            return result;
        }

        // NEED 1 more condition
        public async Task<string> CreateCallCardAsync(LibCallCard callCard)
        {
            var book = await _context.LibBooks.FirstOrDefaultAsync(x => x.Isbn == callCard.Isbn);
            if (book == null) throw new NonExistenceException(String.Format("Call card with isbn {0} not found", callCard.Isbn));

            var membership = await _context.LibMemberships.FirstOrDefaultAsync(x => x.MembershipId == callCard.MembershipId);
            if (membership == null) 
                throw new NonExistenceException(
                    String.Format("Call card with membership {0} not found", callCard.MembershipId));

            if (callCard.Status == 1)
                throw new ExpiredMembershipException(
                    String.Format("Membership {0} has expired", callCard.MembershipId));

            if (book.Quantity == 0) 
                throw new OutOfBookException(
                    String.Format("Cannot create call card for membership {0} due to isbn {1} is out of stock", 
                    callCard.MembershipId, callCard.Isbn));

            foreach(var mCallCard in membership.LibCallCards)
                if (mCallCard.Status == 2) 
                    throw new DueCallCardException(
                        String.Format("Cannot create call card for membership {0} due to membership has due call card {1}", 
                        membership.MembershipId, mCallCard.CallCardId));

            book.Quantity--;
            _context.LibCallCards.Add(callCard);
            await _context.SaveChangesAsync();
            return callCard.CallCardId;
        }

        public async Task<string> UpdateCallCardStatusAsync(string callCardId, int status)
        {
            var callCard = await _context.LibCallCards.FirstOrDefaultAsync(x => x.CallCardId == callCardId);
            if (callCard == null) throw new NonExistenceException(callCardId);

            var book = await _context.LibBooks.FirstOrDefaultAsync(x => x.Isbn == callCard.Isbn);
            if (book == null) throw new NonExistenceException(callCard.Isbn);

            switch(status)
            {
                case 0:
                    if (book.Quantity == 0) throw new OutOfBookException(callCard.Isbn);
                    book.Quantity--;
                    break;
                case 1:
                    book.Quantity++;
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }

            callCard.Status = status;
            await _context.SaveChangesAsync();

            LibCallCardEventArgs args = new LibCallCardEventArgs();
            args.CallCardId = callCardId;
            args.Status = status;
            await (OnStatusChangedAsync?.InvokeAsync(this, args) ?? Task.CompletedTask);

            return callCardId;
        }
    }
}
