using Microsoft.EntityFrameworkCore;
using Server.Helpers.Exceptions;
using Server.Models;

namespace Server.Repositories
{
    public class LibBookAuditCardsRepository : ILibBookAuditCardsRepository
    {
        private readonly LibraryManagementContext _context;

        public LibBookAuditCardsRepository(LibraryManagementContext context)
        {
            _context = context;
        }

        public async Task<List<LibBookAuditCard>> GetBookAuditCardsAsync()
        {
            var bookAuditCards = await _context.LibBookAuditCards.ToListAsync();
            return bookAuditCards;
        }

        public async Task<LibBookAuditCard> GetBookAuditCardByIdAsync(string bookAuditCardId)
        {
            var bookAuditCard = await _context.LibBookAuditCards.FirstOrDefaultAsync(x => x.BookAuditCardId == bookAuditCardId);
            if (bookAuditCard == null) throw new NonExistenceException(string.Format("Book audit card {0} not found", bookAuditCardId));
            return bookAuditCard;
        }

        public async Task<LibBookAuditCard> GetBookAuditCardByBookIdAsync(string bookId)
        {
            var bookAuditCard = await _context.LibBookAuditCards.FirstOrDefaultAsync(x => x.BookId == bookId);
            if (bookAuditCard == null) throw new NonExistenceException(string.Format("Book audit card for book {0} not found", bookId));
            return bookAuditCard;
        }

        public async Task<string> CreateBookAuditCardFromAddedBookAsync(LibBook addedBook)
        {
            LibBookAuditCard bookAuditCard = new LibBookAuditCard(addedBook.BookId, 0, null, addedBook.ReceiverId);
            _context.LibBookAuditCards.Add(bookAuditCard);
            await _context.SaveChangesAsync();
            return bookAuditCard.BookAuditCardId;
        }

        public async Task<string> CreateBookAuditCardFromUpdatedBookAsync(LibBook updatedBook)
        {
            LibBookAuditCard bookAuditCard = new LibBookAuditCard(updatedBook.BookId, 1, null, updatedBook.ModifierId);
            _context.LibBookAuditCards.Add(bookAuditCard);
            await _context.SaveChangesAsync();
            return bookAuditCard.BookAuditCardId;
        }

        public async Task<string> CreateBookAuditCardFromRemovedBookAsync(LibBook removedBook, int? reason)
        {
            LibBookAuditCard bookAuditCard = new LibBookAuditCard(removedBook.BookId, 2, reason, removedBook.ModifierId);
            _context.LibBookAuditCards.Add(bookAuditCard);
            await _context.SaveChangesAsync();
            return bookAuditCard.BookAuditCardId;
        }
    }
}
