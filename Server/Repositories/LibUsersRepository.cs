using Microsoft.EntityFrameworkCore;
using Server.Helpers.Exceptions;
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
            var users = await _context.LibUsers.ToListAsync();
            return users;
        }

        public async Task<LibUser> GetUserByIdAsync(string userId)
        {
            var user = await _context.LibUsers.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user == null) throw new NonExistenceException(string.Format("User {0} is not found", userId));
            return user;
        }

        public async Task<LibUser> GetUserByIdAndPasswordAsync(string userId, string password)
        {
            var user = await _context.LibUsers.FirstOrDefaultAsync(x => x.UserId == userId && x.Password == password);
            if (user == null) throw new NonExistenceException(string.Format("User {0} is not found", userId));
            return user;
        }

        public async Task<string> CreateUserAsync(LibUser userToCreate)
        {
            _context.LibUsers.Add(userToCreate);
            await _context.SaveChangesAsync();
            return userToCreate.UserId;
        }

        public async Task<string> UpdateUserAsync(LibUser userToUpdate)
        {
            var user = await _context.LibUsers.FirstOrDefaultAsync(x => x.UserId == userToUpdate.UserId);
            if (user == null) throw new NonExistenceException(string.Format("User {0} is not found", userToUpdate.UserId));

            user.Password = userToUpdate.Password;
            user.Name = userToUpdate.Name;
            user.Address = userToUpdate.Address;
            user.Dob = userToUpdate.Dob;
            user.Mobile = userToUpdate.Mobile;
            user.Education = userToUpdate.Education;
            user.Department = userToUpdate.Department;
            user.Position = userToUpdate.Position;
            await _context.SaveChangesAsync();
            return userToUpdate.UserId;
        }

        public async Task<string> DisableUserAsync(string userId)
        {
            var user = await _context.LibUsers.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user == null) throw new NonExistenceException(string.Format("User {0} is not found", userId));

            user.Status = 1;
            _context.LibUsers.Update(user);
            await _context.SaveChangesAsync();
            return userId;
        }

        public async Task<string> EnableUserAsync(string userId)
        {
            var user = await _context.LibUsers.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user == null) throw new NonExistenceException(string.Format("User {0} is not found", userId));

            user.Status = 0;
            _context.LibUsers.Update(user);
            await _context.SaveChangesAsync();
            return userId;
        }
    }
}
