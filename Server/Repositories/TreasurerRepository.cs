using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Repositories
{
    public class TreasurerRepository: ITreasurerRepository
    {
        private readonly LibraryManagementContext _context;

        public TreasurerRepository(LibraryManagementContext context)
        {
            _context = context;
        }



        public async Task<LibCallCard> GetCallCardByIdAsync(int Id)
        {
            var result = await _context.LibCallCards.FirstOrDefaultAsync(x => x.Id == Id);

            if (result == null) throw new ArgumentException(Id + " not found");

            return result;
        }

        public async Task<List<LibCallCard>> GetCallCardAsync()
        {
            var result = await _context.LibCallCards.ToListAsync();
            return result;
        }

    }
}
