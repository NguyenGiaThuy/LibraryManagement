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
            if (membership == null) throw new NonExistenceException(string.Format("Membership {0} is not found", membershipId));
            return membership;
        }

        public async Task<LibMembership> GetMembershipBySocialIdAsync(string socialId)
        {
            var membership = await _context.LibMemberships.FirstOrDefaultAsync(x => x.SocialId == socialId);
            if (membership == null) throw new NonExistenceException(string.Format("Membership with social ID {0} is not found", socialId));
            return membership;
        }

        public async Task<LibMembership> CreateMembershipFromMemberAsync(LibMember member)
        {
            LibMembership membership = new LibMembership(member.MemberId, member.SocialId, member.CreatorId);
            _context.LibMemberships.Add(membership);
            await _context.SaveChangesAsync();
            return await GetMembershipByIdAsync(membership.MembershipId);
        }

        public async Task<LibMembership> DisableMembershipAsync(LibMembership membershipToDisable)
        {
            var membership = await _context.LibMemberships.FirstOrDefaultAsync(x => x.MembershipId == membershipToDisable.MembershipId);
            if (membership == null) throw new NonExistenceException(string.Format("Membership {0} is not found", membershipToDisable.MembershipId));

            membership.ModifierId = membershipToDisable.ModifierId;
            membership.ModifiedDate = DateTime.Now;
            membership.Status = 1;
            await _context.SaveChangesAsync();
            return await GetMembershipByIdAsync(membershipToDisable.MembershipId);
        }

        public async Task<LibMembership> EnableMembershipAsync(LibMembership membershipToDisable)
        {
            var membership = await _context.LibMemberships.FirstOrDefaultAsync(x => x.MembershipId == membershipToDisable.MembershipId);
            if (membership == null) throw new NonExistenceException(string.Format("Membership {0} is not found", membershipToDisable.MembershipId));

            // Reset membership
            membership.StartDate = DateTime.Now;
            membership.ExpiryDate = DateTime.Now.AddMonths(6);
            membership.Type = 0;
            membership.ModifierId = membershipToDisable.ModifierId;
            membership.ModifiedDate = DateTime.Now;
            membership.Status = 0;
            await _context.SaveChangesAsync();
            return await GetMembershipByIdAsync(membershipToDisable.MembershipId);
        }

        public async Task<LibMembership> ExtendMembershipAsync(LibMembership membershipToDisable)
        {
            var membership = await _context.LibMemberships.FirstOrDefaultAsync(x => x.MembershipId == membershipToDisable.MembershipId);
            if (membership == null) throw new NonExistenceException(string.Format("Membership {0} is not found", membershipToDisable.MembershipId));

            membership.ExpiryDate = membership.ExpiryDate.Value.AddMonths(6);
            membership.ModifierId = membershipToDisable.ModifierId;
            membership.ModifiedDate = DateTime.Now;

            // Enable and reset membership if expiry date > now
            if (membership.Status == 1 && membership.ExpiryDate > DateTime.Now)
            {
                membership.StartDate = DateTime.Now;
                membership.Type = 0;
                membership.Status = 0;
            }

            // Change membership type if tenure > 1 year
            if ((membership.ExpiryDate.Value - membership.StartDate.Value).Days >= 365) membership.Type = 1;

            await _context.SaveChangesAsync();
            return await GetMembershipByIdAsync(membershipToDisable.MembershipId);
        }

        public async Task<LibMembership> UpdateMembershipStatusOnExpiredAsync(string membershipId)
        {
            var membership = await _context.LibMemberships.FirstOrDefaultAsync(x => x.MembershipId == membershipId);
            if (membership == null) throw new NonExistenceException(string.Format("Membership {0} is not found", membershipId));

            if (DateTime.Now >= membership.ExpiryDate)
            {
                membership.Status = 1;
                await _context.SaveChangesAsync();
            }

            return await GetMembershipByIdAsync(membershipId);
        }
    }
}
