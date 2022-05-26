using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Repositories
{
    public class LibMembershipsRepository : ILibMembershipsRepository
    {
        private readonly LibraryManagementContext _context;

        public LibMembershipsRepository(LibraryManagementContext context)
        {
            _context = context;
        }

        public async Task<List<LibMembership>> GetMembershipsAsync()
        {
            var result = await _context.LibMemberships.ToListAsync();
            return result;
        }

        public async Task<LibMembership> GetMembershipByIdAsync(string membershipId)
        {
            var result = await _context.LibMemberships.FirstOrDefaultAsync(x => x.MembershipId == membershipId);

            if (result == null) throw new ArgumentException(membershipId + " not found");

            return result;
        }

        public async Task<string> CreateMembershipAsync(LibMembership membership)
        {
            _context.LibMemberships.Add(membership);
            await _context.SaveChangesAsync();
            return membership.MembershipId;
        }

        public async Task<string> DisableMembershipAsync(string membershipId)
        {
            var result = await _context.LibMemberships.FirstOrDefaultAsync(x => x.MembershipId == membershipId);

            if (result == null) throw new ArgumentException(membershipId + " not found");

            result.Status = 1;
            await _context.SaveChangesAsync();
            return membershipId;
        }

        public async Task<string> EnableMembershipAsync(string membershipId)
        {
            var result = await _context.LibMemberships.FirstOrDefaultAsync(x => x.MembershipId == membershipId);

            if (result == null) throw new ArgumentException(membershipId + " not found");

            result.Status = 0;
            await _context.SaveChangesAsync();
            return membershipId;
        }

        public async Task<string> ExtendMembershipAsync(string membershipId)
        {
            var result = await _context.LibMemberships.FirstOrDefaultAsync(x => x.MembershipId == membershipId);

            if (result == null) throw new ArgumentException(membershipId + " not found");

            result.ExpiryDate = DateOnly.FromDateTime(DateTime.Now.AddYears(1));
            await _context.SaveChangesAsync();
            return membershipId;
        }
    }
}
