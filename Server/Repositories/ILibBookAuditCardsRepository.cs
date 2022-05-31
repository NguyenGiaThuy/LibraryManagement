using Server.Models;

namespace Server.Repositories
{
    public interface ILibBookAuditCardsRepository
    {
        public Task<List<LibBookAuditCard>> GetBookAuditCardsAsync();
        public Task<LibBookAuditCard> GetBookAuditCardByIdAsync(string bookAuditCardId);
        public Task<LibBookAuditCard> GetBookAuditCardByBookIdAsync(string bookId);
        public Task<string> CreateBookAuditCardFromAddedBookAsync(LibBook addedBook);
        public Task<string> CreateBookAuditCardFromUpdatedBookAsync(LibBook updatedBook);
        public Task<string> CreateBookAuditCardFromRemovedBookAsync(LibBook removedBook, int? reason);
    }
}
