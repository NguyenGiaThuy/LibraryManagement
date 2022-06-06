using Server.Models;

namespace Server.Repositories
{
    public interface ILibUsersRepository
    {
        public Task<List<LibUser>> GetUsersAsync();
        public Task<LibUser> GetUserByIdAndPasswordAsync(string userId, string password);
        public Task<string> CreateUserAsync(LibUser userToCreate);
        public Task<string> UpdateUserAsync(LibUser userToUpdate);
        public Task<string> DisableUserAsync(string userId);
        public Task<string> EnableUserAsync(string userId);
    }
}
