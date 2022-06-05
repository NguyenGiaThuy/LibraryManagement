using Server.Models;

namespace Server.Repositories
{
    public interface ILibBooksRepository
    {
        public Task<List<LibBook>> GetBooksAsync();
        public Task<LibBook> GetBookByIdAsync(string bookId);
        public Task<string> AddBookAsync(LibBook bookToAdd);
        public Task<string> UpdateBookAsync(LibBook bookToUpdate);
        public Task<string> RemoveBookAsync(LibBook bookToRemove);
    }
}
