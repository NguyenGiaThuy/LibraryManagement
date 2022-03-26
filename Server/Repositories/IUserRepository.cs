using Server.Models;

namespace Server.Repositories
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAll();
    }
}
