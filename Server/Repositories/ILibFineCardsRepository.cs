using Server.Models;

namespace Server.Repositories
{
    public interface ILibFineCardsRepository
    {
        public Task<List<LibFineCard>> GetFineCardsAsync();
        public Task<LibFineCard> GetFineCardByIdAsync(string fineCardId);
        public Task<LibFineCard> GetFineCardByCallCardIdAsync(string callCardId);
        public Task<LibFineCard> CreateFineCardAsync(LibFineCard fineCardToCreate);
        //public void UpdateAllFineCardsArrearsAsync();
        public Task<LibFineCard> UpdateFineCardArrearsAsync(string fineCardId);
        public Task<LibFineCard> CloseFineCardAsync(string fineCardId);
    }
}
