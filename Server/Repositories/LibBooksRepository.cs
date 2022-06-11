using Microsoft.EntityFrameworkCore;
using Server.Helpers.Exceptions;
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
            var books = await _context.LibBooks.ToListAsync();
            return books;
        }

        public async Task<LibBook> GetBookByIdAsync(string bookId)
        {
            var book = await _context.LibBooks.FirstOrDefaultAsync(x => x.BookId == bookId);
            if (book == null) throw new NonExistenceException(string.Format("Book {0} is not found", bookId));
            return book;
        }

        public async Task<LibBook> AddBookAsync(LibBook bookToAdd)
        {
            _context.LibBooks.Add(bookToAdd);
            await _context.SaveChangesAsync();
            return await GetBookByIdAsync(bookToAdd.BookId);
        }

        public async Task<LibBook> UpdateBookAsync(LibBook bookToUpdate)
        {
            var book = await _context.LibBooks.FirstOrDefaultAsync(x => x.BookId == bookToUpdate.BookId);
            if (book == null) throw new NonExistenceException(string.Format("Book {0} is not found", bookToUpdate.BookId));

            book.Isbn = bookToUpdate.Isbn;
            book.Title = bookToUpdate.Title;
            book.Genre = bookToUpdate.Genre;
            book.Author = bookToUpdate.Author;
            book.Publisher = bookToUpdate.Publisher;
            book.PublishedDate = bookToUpdate.PublishedDate;
            book.Price = bookToUpdate.Price;
            book.Status = bookToUpdate.Status;
            book.ModifiedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return await GetBookByIdAsync(bookToUpdate.BookId);
        }

        public async Task<LibBook> RemoveBookAsync(LibBook bookToRemove)
        {
            var book = await _context.LibBooks.FirstOrDefaultAsync(x => x.BookId == bookToRemove.BookId);
            if (book == null) throw new NonExistenceException(string.Format("Book {0} is not found", bookToRemove.BookId));

            // Check if book is available
            if (book.Status == 1)
                throw new UnavailableBookException(
                    string.Format("Cannot remove book {0} due to it is unavailable", bookToRemove.BookId));

            // Remove book
            book.Status = 1;
            await _context.SaveChangesAsync();
            return await GetBookByIdAsync(bookToRemove.BookId);
        }
    }
}
