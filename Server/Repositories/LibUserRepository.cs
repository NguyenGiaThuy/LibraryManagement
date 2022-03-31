using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Repositories
{
    public class LibUserRepository : ILibUserRepository
    {
        private readonly LibraryManagementContext _context;

        public LibUserRepository(LibraryManagementContext context)
        {
            _context = context;
        }

        public async Task<string> CreateUserAsync(LibUser user)
        {
            _context.LibUsers.Add(user);
            await _context.SaveChangesAsync();
            return user.UserId;
        }

        public async Task<string> DeleteUserAsync(string userId)
        {
            var result = _context.LibUsers.FirstOrDefault(x => x.UserId == userId);

            if (result == null) throw new ArgumentException(userId + " not found");

            _context.LibUsers.Remove(result);
            await _context.SaveChangesAsync();
            return userId;
        }

        public async Task<LibUser> GetUserByIdAsync(string userId)
        {
            var result = await _context.LibUsers.FirstOrDefaultAsync(x => x.UserId == userId);

            if (result == null) throw new ArgumentException(userId + " not found");

            return result;
        }

        public async Task<List<LibUser>> GetUsersAsync()
        {
            var result = await _context.LibUsers.ToListAsync();
            return result;
        }

        public async Task<string> UpdateUserAsync(string userId, LibUser user)
        {
            var result = _context.LibUsers.FirstOrDefault(x => x.UserId == userId);

            if (result == null) throw new ArgumentException(userId + " not found");

            _context.LibUsers.Update(user);
            await _context.SaveChangesAsync();
            return userId;
        }
    }
}
