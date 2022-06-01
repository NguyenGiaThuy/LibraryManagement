using Microsoft.EntityFrameworkCore;
using Server.Helpers.Exceptions;
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
            var memberships = await _context.LibMemberships.ToListAsync();
            return memberships;
        }

        public async Task<LibMembership> GetMembershipByIdAsync(string membershipId)
        {
            var membership = await _context.LibMemberships.FirstOrDefaultAsync(x => x.MembershipId == membershipId);
            if (membership == null) throw new NonExistenceException(string.Format("Membership {0} not found", membershipId));
            return membership;
        }

        public async Task<LibMembership> GetMembershipBySocialIdAsync(string socialId)
        {
            var membership = await _context.LibMemberships.FirstOrDefaultAsync(x => x.SocialId == socialId);
            if (membership == null) throw new NonExistenceException(string.Format("Membership with social ID {0} not found", socialId));
            return membership;
        }

        public async Task<string> CreateMembershipFromMemberAsync(LibMember member)
        {
            LibMembership membership = new LibMembership(member.MemberId, member.SocialId, member.CreatorId);
            _context.LibMemberships.Add(membership);
            await _context.SaveChangesAsync();
            return membership.MemberId;
        }

        public async Task<string> DisableMembershipAsync(LibMembership membershipToDisable)
        {
            var membership = await _context.LibMemberships.FirstOrDefaultAsync(x => x.MembershipId == membershipToDisable.MembershipId);
            if (membership == null) throw new NonExistenceException(string.Format("Membership {0} not found", membershipToDisable.MembershipId));

            membership.ModifierId = membershipToDisable.ModifierId;
            membership.ModifiedDate = DateTime.Now;
            membership.Status = 1;
            await _context.SaveChangesAsync();
            return membershipToDisable.MembershipId;
        }

        public async Task<string> EnableMembershipAsync(LibMembership membershipToDisable)
        {
            var membership = await _context.LibMemberships.FirstOrDefaultAsync(x => x.MembershipId == membershipToDisable.MembershipId);
            if (membership == null) throw new NonExistenceException(string.Format("Membership {0} not found", membershipToDisable.MembershipId));

            // Reset membership
            membership.StartDate = DateTime.Now;
            membership.ExpiryDate = DateTime.Now.AddMonths(6);
            membership.MembershipType = 0;
            membership.ModifierId = membershipToDisable.ModifierId;
            membership.ModifiedDate = DateTime.Now;
            membership.Status = 0;
            await _context.SaveChangesAsync();
            return membershipToDisable.MembershipId;
        }

        public async Task<string> ExtendMembershipAsync(LibMembership membershipToDisable)
        {
            var membership = await _context.LibMemberships.FirstOrDefaultAsync(x => x.MembershipId == membershipToDisable.MembershipId);
            if (membership == null) throw new NonExistenceException(string.Format("Membership {0} not found", membershipToDisable.MembershipId));

            membership.ExpiryDate = DateTime.Now.AddMonths(6);
            membership.ModifierId = membershipToDisable.ModifierId;
            membership.ModifiedDate = DateTime.Now;

            // Change membership type if tenure > 1 year
            if ((membership.ExpiryDate.Value - membership.StartDate.Value).TotalDays >= 365) membership.MembershipType = 1;

            await _context.SaveChangesAsync();
            return membershipToDisable.MembershipId;
        }
    }
}
