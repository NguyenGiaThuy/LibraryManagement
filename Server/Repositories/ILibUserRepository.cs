using Server.Models;

namespace Server.Repositories
{
    public interface ILibUserRepository
    {
        public Task<List<LibUser>> GetUsersAsync();
        public Task<LibUser> GetUserByIdAsync(string userId);
        public Task<string> CreateUserAsync(LibUser user);
        public Task<string> UpdateUserAsync(string userId, LibUser user);
        public Task<string> DeleteUserAsync(string userId);
    }
}
