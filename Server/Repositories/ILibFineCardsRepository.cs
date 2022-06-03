using Server.Models;

namespace Server.Repositories
{
    public interface ILibFineCardsRepository
    {
        public Task<List<LibFineCard>> GetFineCardsAsync();
        public Task<LibFineCard> GetFineCardByIdAsync(string fineCardId);
        public Task<LibFineCard> GetFineCardByCallCardIdAsync(string callCardId);
        public Task<string> CreateFineCardAsync(LibFineCard fineCardToCreate);
        //public void UpdateAllFineCardsArrearsAsync();
        public Task<string> UpdateFineCardArrearsAsync(string fineCardId);
        public Task<string> CloseFineCardAsync(string fineCardId);
    }
}
