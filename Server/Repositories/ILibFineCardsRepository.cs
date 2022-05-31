using Server.Models;

namespace Server.Repositories
{
    public interface ILibFineCardsRepository
    {
        public Task<List<LibFineCard>> GetFineCardsAsync();
        public Task<List<LibFineCard>> GetFineCardsByIsbnAsync(string isbn);
        public Task<List<LibFineCard>> GetFineCardsByMembershipIdAsync(string membershipId);
        public Task<LibFineCard> GetFineCardByIdAsync(string fineCardId);
        public Task<string> CreateFineCardAsync(LibFineCard fineCard);
        public Task<string> UpdateFineCardStatusAsync(string fineCardId, int status);
    }
}
