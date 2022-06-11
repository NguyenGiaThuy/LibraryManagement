using Server.Models;

namespace Server.Repositories
{
    public interface ILibMembershipsRepository
    {
        public Task<List<LibMembership>> GetMembershipsAsync();
        public Task<LibMembership> GetMembershipByIdAsync(string membershipId);
        public Task<LibMembership> GetMembershipBySocialIdAsync(string socialId);
        public Task<LibMembership> CreateMembershipFromMemberAsync(LibMember member);
        public Task<LibMembership> DisableMembershipAsync(LibMembership membershipToDisable);
        public Task<LibMembership> EnableMembershipAsync(LibMembership membershipToEnable);
        public Task<LibMembership> ExtendMembershipAsync(LibMembership membershipToExtend);
        public Task<LibMembership> UpdateMembershipStatusOnExpiredAsync(string membershipId);
    }
}
