using Server.Models;

namespace Server.Repositories
{
    public interface ILibCallCardsRepository
    {
        public Task<List<LibCallCard>> GetCallCardsAsync();
        public Task<List<LibCallCard>> GetCallCardsByIsbnAsync(string isbn);
        public Task<List<LibCallCard>> GetCallCardsByMembershipIdAsync(string membershipId);
        public Task<LibCallCard> GetCallCardByIdAsync(string callCardId);
        public Task<string> CreateCallCardAsync(LibCallCard callCard);
        public Task<string> UpdateCallCardStatusAsync(string callCardId, int status);
    }
}
