using Server.Models;

namespace Server.Repositories
{
    public interface ILibBookAuditCardsRepository
    {
        public Task<List<LibBookAuditCard>> GetBookAuditCardsAsync();
        public Task<LibBookAuditCard> GetBookAuditCardByIdAsync(string bookAuditCardId);
        public Task<LibBookAuditCard> GetBookAuditCardByBookIdAsync(string bookId);
        public Task<LibBookAuditCard> CreateBookAuditCardFromAddedBookAsync(LibBook addedBook);
        public Task<LibBookAuditCard> CreateBookAuditCardFromUpdatedBookAsync(LibBook updatedBook);
        public Task<LibBookAuditCard> CreateBookAuditCardFromRemovedBookAsync(LibBook removedBook, int? reason);
    }
}
