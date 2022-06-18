using Server.Models;

namespace Server.Repositories
{
    public interface ILibCallCardsRepository
    {
        public Task<List<LibCallCard>> GetCallCardsAsync();
        public Task<LibCallCard> GetCallCardByIdAsync(string callCardId);
        public Task<LibCallCard> GetCallCardByBookIdAsync(string bookId);
        public Task<LibCallCard> CreateCallCardAsync(LibCallCard callCardToCreate);
        //public void UpdateAllCallCardsStatusesAsync();
        public Task<LibCallCard> UpdateCallCardStateAsync(string callCardId, int state);
    }
}
