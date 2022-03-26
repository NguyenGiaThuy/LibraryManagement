using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TestContext _context;

        public UserRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }
    }
}
