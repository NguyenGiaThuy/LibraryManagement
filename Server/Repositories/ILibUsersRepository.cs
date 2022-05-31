using Server.Models;

namespace Server.Repositories
{
    public interface ILibUsersRepository
    {
        public Task<List<LibUser>> GetUsersAsync();
        public Task<LibUser> GetUserByIdAsync(string userId);
        public Task<string> CreateUserAsync(LibUser user);
        public Task<string> UpdateUserAsync(LibUser user);
        public Task<string> DisableUserAsync(string userId);
        public Task<string> EnableUserAsync(string userId);
    }
}
