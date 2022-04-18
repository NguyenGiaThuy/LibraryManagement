using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Repositories
{
    public class LibLibrarianRepository : ILibLibrarianRepository
    {
        private readonly LibraryManagementContext _context;

        public LibLibrarianRepository(LibraryManagementContext context)
        {
            _context = context;
        }

        public async Task<string> CreateMembershipAsync(LibMembership membership)
        {
            _context.LibMemberships.Add(membership);
            await _context.SaveChangesAsync();
            return membership.MembershipId;
        }

        public async Task<string> DeleteMembershipAsync(string membershipId)
        {
            var result = _context.LibMemberships.FirstOrDefault(x => x.MembershipId == membershipId);

            if (result == null) throw new ArgumentException(membershipId + " not found");

            _context.LibMemberships.Remove(result);
            await _context.SaveChangesAsync();
            return membershipId;
        }

        public async Task<LibMembership> GetMembershipByIdAsync(string membershipId)
        {
            var result = await _context.LibMemberships.FirstOrDefaultAsync(x => x.MembershipId == membershipId);

            if (result == null) throw new ArgumentException(membershipId + " not found");

            return result;
        }

        public async Task<List<LibMembership>> GetMembershipsAsync()
        {
            var result = await _context.LibMemberships.ToListAsync();
            return result;
        }

        public async Task<string> UpdateMembershipAsync(string membershipId, LibMembership membership)
        {
            var result = _context.LibMemberships.FirstOrDefault(x => x.MembershipId == membershipId);

            if (result == null) throw new ArgumentException(membershipId + " not found");

            _context.LibMemberships.Update(membership);
            await _context.SaveChangesAsync();
            return membershipId;
        }

        public async Task<LibBook> GetBookByISBNAsync(string isbn)
        {
            var result = await _context.LibBooks.FirstOrDefaultAsync(x => x.Isbn == isbn);

            if (result == null) throw new ArgumentException(isbn + " not found");

            return result;
        }

        public async Task<List<LibBook>> GetBooksAsync()
        {
            var result = await _context.LibBooks.ToListAsync();
            return result;
        }

        public async Task<string> UpdateBookAsync(string isbn, LibBook book)
        {
            var result = _context.LibBooks.FirstOrDefault(x => x.Isbn == isbn);

            if (result == null) throw new ArgumentException(isbn + " not found");

            _context.LibBooks.Update(book);
            await _context.SaveChangesAsync();
            return isbn;
        }

        public async Task<List<LibCallCard>> GetCallCardAsync()
        {
            var result = await _context.LibCallCards.ToListAsync();
            return result;
        }

        public async Task<LibCallCard> GetCallCardByIdAsync(int Id)
        {
            var result = await _context.LibCallCards.FirstOrDefaultAsync(x => x.Id == Id);

            if (result == null) throw new ArgumentException(Id + " not found");

            return result;
        }

        public async Task<int> CreateCallCardAsync(LibCallCard callcard)
        {
            _context.LibCallCards.Add(callcard);
            await _context.SaveChangesAsync();
            return callcard.Id;
        }

        public async Task<int> UpdateCallCardAsync(int id, LibCallCard callcard)
        {
            var result = _context.LibCallCards.FirstOrDefault(x => x.Id == id);

            if (result == null) throw new ArgumentException(id + " not found");

            _context.LibCallCards.Update(callcard);
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
