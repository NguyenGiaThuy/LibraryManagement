using Server.Models;

namespace Server.Repositories
{
    public interface ILibBooksRepository
    {
        public Task<List<LibBook>> GetBooksAsync();
        public Task<LibBook> GetBookByIdAsync(string bookId);
        public Task<LibBook> AddBookAsync(LibBook bookToAdd);
        public Task<LibBook> UpdateBookAsync(LibBook bookToUpdate);
        public Task<LibBook> RemoveBookAsync(LibBook bookToRemove);
    }
}
