using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("LibCallCards")]
    public class LibCallCard
    {
        public LibCallCard(string bookId, DateTime? dueDate, string membershipId, string? creatorId)
        {
            BookId = bookId;
            DueDate = dueDate;
            MembershipId = membershipId;
            Status = 0;
            CreatorId = creatorId;
            CreatedDate = DateTime.Now;
            CallCardId = string.Concat("CALL", (BookId + CreatedDate.ToString()).GetHashCode().ToString().AsSpan(1, 6));
        }

        [Key]
        [StringLength(10)]
        public string CallCardId { get; set; } = null!;
        public DateTime? DueDate { get; set; }
        [ForeignKey("Book")]
        [Required]
        public string BookId { get; set; }
        [ForeignKey("Membership")]
        [Required]
        public string MembershipId { get; set; }
        [Range(0, 3)]
        public int? Status { get; set; }
        [ForeignKey("Creator")]
        public string? CreatorId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual LibBook? Book { get; set; }
        public virtual LibMembership? Membership { get; set; }
        public virtual LibUser? Creator { get; set; }
    }
}
