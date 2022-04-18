using Server.Models;

namespace Server.Repositories
{
    public interface ILibLibrarianRepository
    {
        Task<int> CreateCallCardAsync(LibCallCard callcard);
        Task<string> CreateMembershipAsync(LibMembership membership);
        Task<string> DeleteMembershipAsync(string membershipId);
        Task<LibBook> GetBookByISBNAsync(string isbn);
        Task<List<LibBook>> GetBooksAsync();
        Task<List<LibCallCard>> GetCallCardAsync();
        Task<LibCallCard> GetCallCardByIdAsync(int Id);
        Task<LibMembership> GetMembershipByIdAsync(string membershipId);
        Task<List<LibMembership>> GetMembershipsAsync();
        Task<string> UpdateBookAsync(string isbn, LibBook book);
        Task<int> UpdateCallCardAsync(int id, LibCallCard callcard);
        Task<string> UpdateMembershipAsync(string membershipId, LibMembership membership);
    }
}