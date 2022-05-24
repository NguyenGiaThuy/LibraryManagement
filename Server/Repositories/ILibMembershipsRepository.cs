using Server.Models;

namespace Server.Repositories
{
    public interface ILibMembershipsRepository
    {
        public Task<List<LibMembership>> GetMembershipsAsync();
        public Task<LibMembership> GetMembershipByIdAsync(string membershipId);
        public Task<string> CreateMembershipAsync(LibMembership membership);
        public Task<string> DisableMembershipAsync(string membershipId);
        public Task<string> EnableMembershipAsync(string membershipId);
        public Task<string> ExtendMembershipAsync(string membershipId);
    }
}
