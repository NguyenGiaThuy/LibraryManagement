using Microsoft.EntityFrameworkCore;
using Server.Helpers.Exceptions;
using Server.Models;

namespace Server.Repositories
{
    public class LibMembersRepository : ILibMembersRepository
    {
        private readonly LibraryManagementContext _context;

        public LibMembersRepository(LibraryManagementContext context)
        {
            _context = context;
        }

        public async Task<List<LibMember>> GetMembersAsync()
        {
            var members = await _context.LibMembers.ToListAsync();
            return members;
        }
        public async Task<LibMember> GetMemberByIdAsync(string memberId)
        {
            var member = await _context.LibMembers.FirstOrDefaultAsync(x => x.MemberId == memberId);
            if (member == null) throw new NonExistenceException(string.Format("Member {0} not found", memberId));
            return member;
        }

        public async Task<LibMember> GetMemberByMembershipIdAsync(string membershipId)
        {
            var member = await _context.LibMembers.FirstOrDefaultAsync(x => x.MembershipId == membershipId);
            if (member == null) throw new NonExistenceException(string.Format("Member with membership ID {0} not found", membershipId));
            return member;
        }

        public async Task<LibMember> GetMemberBySocialIdAsync(string socialId)
        {
            var member = await _context.LibMembers.FirstOrDefaultAsync(x => x.SocialId == socialId);
            if (member == null) throw new NonExistenceException(string.Format("Member with social ID {0} not found", socialId));
            return member;
        }

        public async Task<string> CreateMemberAsync(LibMember memberToCreate)
        {
            _context.LibMembers.Add(memberToCreate);
            await _context.SaveChangesAsync();
            return memberToCreate.MemberId;
        }

        public async Task<string> UpdateMemberAsync(LibMember memberToUpdate)
        {
            var member = await _context.LibMembers.FirstOrDefaultAsync(x => x.MemberId == memberToUpdate.MemberId);
            if (member == null) throw new NonExistenceException(string.Format("Member {0} not found", memberToUpdate.MemberId));

            member.SocialId = memberToUpdate.SocialId;
            member.Name = memberToUpdate.Name;
            member.Dob = memberToUpdate.Dob;
            member.Address = memberToUpdate.Address;
            member.Mobile = memberToUpdate.Mobile;
            member.Email = memberToUpdate.Email;
            member.ModifierId = memberToUpdate.ModifierId;
            member.ModifiedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return memberToUpdate.MemberId;
        }
    }
}
