using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Repositories
{
    public class LibFineCardsRepository : ILibFineCardsRepository
    {
        private readonly LibraryManagementContext _context;

        public LibFineCardsRepository(LibraryManagementContext context)
        {
            _context = context;
            LibCallCardsRepository.OnStatusChangedAsync += LibCallCardsRepository_OnStatusChangedAsync;
        }

        ~LibFineCardsRepository()
        {
            LibCallCardsRepository.OnStatusChangedAsync -= LibCallCardsRepository_OnStatusChangedAsync;
        }

        public async Task<List<LibFineCard>> GetFineCardsAsync()
        {
            var result = await _context.LibFineCards.ToListAsync();
            return result;
        }

        public async Task<List<LibFineCard>> GetFineCardsByIsbnAsync(string isbn)
        {
            var query = from fineCard in _context.LibFineCards
                         join callCard in _context.LibCallCards on fineCard.CallCardId equals callCard.CallCardId
                         where callCard.Isbn == isbn
                         select fineCard;

            var result = await query.ToListAsync();

            if (result == null) throw new ArgumentException(isbn + " not found");

            return result;
        }

        public async Task<List<LibFineCard>> GetFineCardsByMembershipIdAsync(string membershipId)
        {
            var query = from fineCard in _context.LibFineCards
                        join callCard in _context.LibCallCards on fineCard.CallCardId equals callCard.CallCardId
                        where callCard.MembershipId == membershipId
                        select fineCard;

            var result = await query.ToListAsync();

            if (result == null) throw new ArgumentException(membershipId + " not found");

            return result;
        }

        public async Task<LibFineCard> GetFineCardByIdAsync(string fineCardId)
        {
            var result = await _context.LibFineCards.FirstOrDefaultAsync(x => x.FineCardId == fineCardId);

            if (result == null) throw new ArgumentException(fineCardId + " not found");

            return result;
        }

        public async Task<string> CreateFineCardAsync(LibFineCard fineCard)
        {
            var callCard = await _context.LibCallCards.FirstOrDefaultAsync(x => x.CallCardId == fineCard.CallCardId);

            if(callCard == null) throw new ArgumentException(fineCard.CallCardId + " not found");

            fineCard.Reason = callCard.Status;
            _context.LibFineCards.Add(fineCard);
            await _context.SaveChangesAsync();
            return fineCard.FineCardId;
        }

        public async Task<string> UpdateFineCardStatusAsync(string fineCardId, int status)
        {
            var result = await _context.LibFineCards.FirstOrDefaultAsync(x => x.FineCardId == fineCardId);

            if (result == null) throw new ArgumentException(fineCardId + " not found");

            result.Status = status;
            await _context.SaveChangesAsync();
            return fineCardId;
        }

        private async Task<string> LibCallCardsRepository_OnStatusChangedAsync(object sender, EventArgs args)
        {
            Helpers.LibCallCardEventArgs callCardArgs = (Helpers.LibCallCardEventArgs)args;

            var callCard = await _context.LibCallCards.FirstOrDefaultAsync(x => x.CallCardId == callCardArgs.CallCardId);
            if (callCard == null) throw new ArgumentException(callCardArgs.CallCardId + " not found");

            var fineCard = await _context.LibFineCards.FirstOrDefaultAsync(x => x.CallCardId == callCard.CallCardId);
            if (fineCard == null) throw new ArgumentException("Fine card with call card ID " + callCard.CallCardId + " not found");
            
            fineCard.Reason = callCard.Status;
            _context.LibFineCards.Add(fineCard);
            await _context.SaveChangesAsync();
            return fineCard.FineCardId;
        }
    }
}
