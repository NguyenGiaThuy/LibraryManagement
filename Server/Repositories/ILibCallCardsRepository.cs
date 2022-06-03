using Server.Models;

namespace Server.Repositories
{
    public interface ILibCallCardsRepository
    {
        public Task<List<LibCallCard>> GetCallCardsAsync();
        public Task<LibCallCard> GetCallCardByIdAsync(string callCardId);
        public Task<LibCallCard> GetCallCardByBookIdAsync(string bookId);
        public Task<string> CreateCallCardAsync(LibCallCard callCardToCreate);
        //public void UpdateAllCallCardsStatusesAsync();
        public Task<string> UpdateCallCardStatusAsync(string callCardId, int status);
    }
}
