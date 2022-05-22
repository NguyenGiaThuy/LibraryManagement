using Server.Models;

namespace Server.Repositories
{
    public interface ILibBooksRepository
    {
        public Task<List<LibBook>> GetBooksAsync();
        public Task<List<LibBook>> GetBooksByGenreAsync(int genre);
        public Task<List<LibBook>> GetBooksByAuthorAsync(string author);
        public Task<List<LibBook>> GetBooksByPublisherAsync(string publisher);
        public Task<LibBook> GetBookByIsbnAsync(string isbn);
        public Task<LibBook> GetBooksByTitleAsync(string title);
        public Task<string> AddBookAsync(LibBook book);
        public Task<string> UpdateBookAsync(string isbn, LibBook book);
        public Task<string> RemoveBookAsync(string userId);
    }
}
