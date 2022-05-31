using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Repositories
{
    public class LibUsersRepository : ILibUsersRepository
    {
        private readonly LibraryManagementContext _context;

        public LibUsersRepository(LibraryManagementContext context)
        {
            _context = context;
        }

        public async Task<List<LibUser>> GetUsersAsync()
        {
            var result = await _context.LibUsers.ToListAsync();
            return result;
        }

        public async Task<LibUser> GetUserByIdAsync(string userId)
        {
            var result = await _context.LibUsers.FirstOrDefaultAsync(x => x.UserId.Contains(userId));

            if (result == null) throw new ArgumentException(userId + " not found");

            return result;
        }

        public async Task<string> CreateUserAsync(LibUser user)
        {
            _context.LibUsers.Add(user);
            await _context.SaveChangesAsync();
            return user.UserId;
        }

        public async Task<string> UpdateUserAsync(LibUser user)
        {
            var result = await _context.LibUsers.FirstOrDefaultAsync(x => x.UserId == user.UserId);

            if (result == null) throw new ArgumentException(user.UserId + " not found");

            result.Password = user.Password;
            result.Name = user.Name;
            result.Address = user.Address;
            result.Dob = user.Dob;
            result.Mobile = user.Mobile;
            result.Education = user.Education;
            result.Department = user.Department;
            result.Position = user.Position;
            result.Status = user.Status;

            await _context.SaveChangesAsync();
            return user.UserId;
        }

        public async Task<string> DisableUserAsync(string userId)
        {
            var result = await _context.LibUsers.FirstOrDefaultAsync(x => x.UserId == userId);

            if (result == null) throw new ArgumentException(userId + " not found");

            result.Status = 1;
            _context.LibUsers.Update(result);
            await _context.SaveChangesAsync();
            return userId;
        }

        public async Task<string> EnableUserAsync(string userId)
        {
            var result = await _context.LibUsers.FirstOrDefaultAsync(x => x.UserId == userId);

            if (result == null) throw new ArgumentException(userId + " not found");

            result.Status = 0;
            _context.LibUsers.Update(result);
            await _context.SaveChangesAsync();
            return userId;
        }
    }
}
