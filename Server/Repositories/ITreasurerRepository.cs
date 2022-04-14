using Server.Models;

namespace Server.Repositories
{
    public interface ITreasurerRepository
    {
        public Task<List<LibCallCard>> GetCallCardAsync();
        public Task<LibCallCard> GetCallCardByIdAsync(int Id);
       
    }
}
