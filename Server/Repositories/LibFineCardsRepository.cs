using Microsoft.EntityFrameworkCore;
using Server.Helpers.Exceptions;
using Server.Models;

namespace Server.Repositories
{
    public class LibFineCardsRepository : ILibFineCardsRepository
    {
        private readonly LibraryManagementContext _context;

        public LibFineCardsRepository(LibraryManagementContext context)
        {
            _context = context;
        }

        public async Task<List<LibFineCard>> GetFineCardsAsync()
        {
            var fineCards = await _context.LibFineCards.ToListAsync();
            return fineCards;
        }

        public async Task<LibFineCard> GetFineCardByIdAsync(string fineCardId)
        {
            var fineCard = await _context.LibFineCards.FirstOrDefaultAsync(x => x.FineCardId == fineCardId);
            if (fineCard == null) throw new NonExistenceException(string.Format("Fine card {0} is not found", fineCardId));
            return fineCard;
        }

        public async Task<LibFineCard> GetFineCardByCallCardIdAsync(string callCardId)
        {
            var fineCard = await _context.LibFineCards.FirstOrDefaultAsync(x => x.CallCardId == callCardId);
            if (fineCard == null) throw new NonExistenceException(string.Format("Fine card for call card {0} is not found", callCardId));
            return fineCard;
        }

        public async Task<LibFineCard> CreateFineCardAsync(LibFineCard fineCardToCreate)
        {
            var callCard = await _context.LibCallCards.FirstOrDefaultAsync(x => x.CallCardId == fineCardToCreate.CallCardId);
            if (callCard == null) throw new NonExistenceException(string.Format("Call card {0} is not found", fineCardToCreate.CallCardId));

            // Check if call card violates rules
            if (callCard.State < 2)
                throw new InvalidOperationException(
                    string.Format("Call card {0} does not violate rules", callCard.CallCardId));

            // Check if call card is active
            if (callCard.Status == 1)
                throw new InvalidOperationException(
                    string.Format("Call card {0} is inactive", callCard.CallCardId));

            // Evaluate fine card reason
            fineCardToCreate.Reason = callCard.State - 2;

            // Evaluate arrears
            LibFineCard? fineCard = null;
            int? daysInArrears;
            int? arrears;
            switch (fineCardToCreate.Reason)
            {
                case 0: // Due
                    fineCard = await _context.LibFineCards.FirstOrDefaultAsync(x => x.Reason == 0 && x.CallCardId == fineCardToCreate.CallCardId);
                    if (fineCard != null)
                        throw new InvalidOperationException(
                            string.Format("Fine card for call card {0} with current reason already exists", fineCardToCreate.CallCardId));

                    daysInArrears = (int?)(DateTime.Now - callCard.DueDate.Value).Days;
                    arrears = 1000 * daysInArrears;
                    fineCardToCreate.DaysInArrears = daysInArrears;
                    fineCardToCreate.Arrears = arrears;
                    break;

                case 1: // Lost
                    fineCard = await _context.LibFineCards.FirstOrDefaultAsync(x => x.Reason == 1 && x.CallCardId == fineCardToCreate.CallCardId);
                    if (fineCard != null)
                        throw new InvalidOperationException(
                            string.Format("Fine card for call card {0} with current reason already exists", fineCardToCreate.CallCardId));

                    var book = await _context.LibBooks.FirstOrDefaultAsync(x => x.BookId == callCard.BookId);
                    if (book == null) throw new NonExistenceException(string.Format("Book {0} not found", fineCardToCreate.CallCardId));

                    arrears = book.Price * 2;
                    fineCardToCreate.Arrears = arrears;

                    break;
            }

            _context.LibFineCards.Add(fineCardToCreate);
            await _context.SaveChangesAsync();
            return await GetFineCardByIdAsync(fineCardToCreate.FineCardId);
        }

        public async Task<LibFineCard> UpdateFineCardArrearsAsync(string fineCardId)
        {
            var fineCard = await _context.LibFineCards.FirstOrDefaultAsync(x => x.FineCardId == fineCardId);
            if (fineCard == null) throw new NonExistenceException(string.Format("Fine card {0} is not found", fineCardId));

            if (fineCard.Reason != 0)
                throw new InvalidOperationException(
                    string.Format("Cannot update fine card {0}'s arrears as its reason is invalid", fineCardId));

            // Update arrears
            int? daysInArrears = (DateTime.Now - fineCard.CreatedDate.Value).Days;
            int? arrears = 1000 * daysInArrears;
            fineCard.DaysInArrears += daysInArrears;
            fineCard.Arrears += arrears;
            await _context.SaveChangesAsync();
            return fineCard;
        }

        public async Task<LibFineCard> CloseFineCardAsync(string fineCardId)
        {
            var fineCard = await _context.LibFineCards.FirstOrDefaultAsync(x => x.FineCardId == fineCardId);
            if (fineCard == null) throw new NonExistenceException(string.Format("Fine card {0} is not found", fineCardId));

            var callCard = await _context.LibCallCards.FirstOrDefaultAsync(x => x.CallCardId == fineCard.CallCardId);
            if (callCard == null) throw new NonExistenceException(string.Format("Call card {0} is not found", fineCard.CallCardId));

            fineCard.Status = 1;
            callCard.Status = 1;
            await _context.SaveChangesAsync();
            return await GetFineCardByIdAsync(fineCard.FineCardId);
        }
    }
}
