using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("LibBookAuditCards")]
    public class LibBookAuditCard
    {
        public LibBookAuditCard(string bookId, int? type, int? reason, string? creatorId)
        {
            BookId = bookId;
            CreatedDate = DateTime.Now;
            Type = type;
            Reason = reason;
            CreatorId = creatorId;
            BookAuditCardId = string.Concat("AUDI", (BookId + CreatedDate.ToString()).GetHashCode().ToString().AsSpan(1, 6));
        }

        [Key]
        [StringLength(10)]
        public string BookAuditCardId { get; set; } = null!;
        [ForeignKey("Book")]
        [Required]
        public string BookId { get; set; }
        [Range(0, 2)]
        public int? Type { get; set; }
        [Range(0, 2)]
        public int? Reason { get; set; }
        [ForeignKey("Creator")]
        public string? CreatorId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual LibBook? Book { get; set; }
        public virtual LibUser? Creator { get; set; }
    }
}
