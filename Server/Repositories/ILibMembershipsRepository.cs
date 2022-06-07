using Server.Models;

namespace Server.Repositories
{
    public interface ILibMembershipsRepository
    {
        public Task<List<LibMembership>> GetMembershipsAsync();
        public Task<LibMembership> GetMembershipByIdAsync(string membershipId);
        public Task<LibMembership> GetMembershipBySocialIdAsync(string socialId);
        public Task<string> CreateMembershipFromMemberAsync(LibMember member);
        public Task<string> DisableMembershipAsync(LibMembership membershipToDisable);
        public Task<string> EnableMembershipAsync(LibMembership membershipToEnable);
        public Task<string> ExtendMembershipAsync(LibMembership membershipToExtend);
        public Task<string> UpdateMembershipStatusOnExpiredAsync(string membershipId);
    }
}
