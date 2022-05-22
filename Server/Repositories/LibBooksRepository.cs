using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Repositories
{
    public class LibBooksRepository : ILibBooksRepository
    {
        private readonly LibraryManagementContext _context;

        public LibBooksRepository(LibraryManagementContext context)
        {
            _context = context;
        }

        public async Task<List<LibBook>> GetBooksAsync()
        {
            var result = await _context.LibBooks.ToListAsync();
            return result;
        }

        public async Task<List<LibBook>> GetBooksByGenreAsync(int genre)
        {
            var result = await _context.LibBooks.Where(x => x.Genre == genre).ToListAsync();
            if (result == null) throw new ArgumentException(genre + " not found");
            return result;
        }

        public async Task<List<LibBook>> GetBooksByAuthorAsync(string author)
        {
            var result = await _context.LibBooks.Where(x => x.Author != null ? x.Author.Contains(author) : false).ToListAsync();
            if (result == null) throw new ArgumentException(author + " not found");
            return result;
        }

        public async Task<List<LibBook>> GetBooksByPublisherAsync(string publisher)
        {
            var result = await _context.LibBooks.Where(x => x.Publisher != null ? x.Publisher.Contains(publisher) : false).ToListAsync();
            if (result == null) throw new ArgumentException(publisher + " not found");
            return result;
        }

        public async Task<LibBook> GetBooksByTitleAsync(string title)
        {
            var result = await _context.LibBooks.FirstOrDefaultAsync(x => x.Title != null ? x.Title.Contains(title) : false);
            if (result == null) throw new ArgumentException(title + " not found");
            return result;
        }

        public async Task<LibBook> GetBookByIsbnAsync(string isbn)
        {
            var result = await _context.LibBooks.FirstOrDefaultAsync(x => x.Isbn == isbn);
            if (result == null) throw new ArgumentException(isbn + " not found");
            return result;
        }

        public async Task<string> AddBookAsync(LibBook book)
        {
            _context.LibBooks.Add(book);
            await _context.SaveChangesAsync();
            return book.Isbn;
        }

        public async Task<string> UpdateBookAsync(string isbn, LibBook book)
        {
            var result = await _context.LibBooks.FirstOrDefaultAsync(x => x.Isbn == isbn);
            if (result == null) throw new ArgumentException(isbn + " not found");

            _context.LibBooks.Update(book);
            await _context.SaveChangesAsync();
            return isbn;
        }

        public async Task<string> RemoveBookAsync(string isbn)
        {
            var result = await _context.LibBooks.FirstOrDefaultAsync(x => x.Isbn == isbn);
            if (result == null) throw new ArgumentException(isbn + " not found");

            var conditionalQuery = from callCard in _context.LibCallCards 
                                   where (callCard.Status == 1 || callCard.Status == 3)
                                   && (callCard.Isbn == isbn)
                                   select callCard;

            var conditionalCallCard = await conditionalQuery.FirstOrDefaultAsync();
            if (conditionalCallCard != null) throw new InvalidOperationException("Cannot remove " + isbn + "due to some books are not returned");

            result.Quantity = 0;
            _context.LibBooks.Update(result);
            await _context.SaveChangesAsync();
            return isbn;
        }
    }
}
