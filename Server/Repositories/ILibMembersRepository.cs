using Server.Models;

namespace Server.Repositories
{
    public interface ILibMembersRepository
    {
        public Task<List<LibMember>> GetMembersAsync();
        public Task<LibMember> GetMemberByIdAsync(string memberId);
        public Task<LibMember> GetMemberByMembershipIdAsync(string membershipId);
        public Task<LibMember> GetMemberBySocialIdAsync(string socialId);
        public Task<string> CreateMemberAsync(LibMember memberToCreate);
        public Task<string> UpdateMemberAsync(LibMember memberToUpdate);
    }
}
