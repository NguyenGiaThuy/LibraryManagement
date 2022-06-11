using Server.Models;

namespace Server.Repositories
{
    public interface ILibMembersRepository
    {
        public Task<List<LibMember>> GetMembersAsync();
        public Task<LibMember> GetMemberByIdAsync(string memberId);
        public Task<LibMember> GetMemberByMembershipIdAsync(string membershipId);
        public Task<LibMember> GetMemberBySocialIdAsync(string socialId);
        public Task<LibMember> CreateMemberAsync(LibMember memberToCreate);
        public Task<LibMember> UpdateMemberAsync(LibMember memberToUpdate);
        public Task<LibMember> UpdateMemberhipIdforMemberAsync(string memberId, string membershipId);
    }
}
