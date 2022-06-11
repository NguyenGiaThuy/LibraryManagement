using Server.Models;

namespace Server.Repositories
{
    public interface ILibUsersRepository
    {
        public Task<List<LibUser>> GetUsersAsync();
        public Task<LibUser> GetUserByIdAsync(string userId);
        public LibUser GetUserByIdAndPassword(string userId, string password);
        public Task<LibUser> CreateUserAsync(LibUser userToCreate);
        public Task<LibUser> UpdateUserAsync(LibUser userToUpdate);
        public Task<LibUser> DisableUserAsync(string userId);
        public Task<LibUser> EnableUserAsync(string userId);
    }
}
