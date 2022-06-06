using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("LibMemberships")]
    public class LibMembership
    {
        public LibMembership(string memberId, string socialId, string? creatorId)
        {
            LibCallCards = new HashSet<LibCallCard>();

            MemberId = memberId;
            SocialId = socialId;
            Type = 0;
            Status = 0;
            CreatorId = creatorId;
            CreatedDate = DateTime.Now;
            StartDate = DateTime.Now;
            ExpiryDate = DateTime.Now.AddMonths(6);
            MembershipId = string.Concat("MEMS", (memberId + CreatedDate.ToString()).GetHashCode().ToString().AsSpan(1, 6));
        }

        [Key]
        [StringLength(10)]
        public string MembershipId { get; set; } = null!;
        [StringLength(12)]
        [Required]
        public string SocialId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        [Range(0, 1)]
        public int? Type { get; set; }
        [Range(0, 1)]
        public int? Status { get; set; }
        [ForeignKey("Member")]
        [Required]
        public string MemberId { get; set; }
        [ForeignKey("Creator")]
        public string? CreatorId { get; set; }
        public DateTime? CreatedDate { get; set; }
        [ForeignKey("Modifier")]
        public string? ModifierId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual LibMember? Member { get; set; }
        public virtual LibUser? Creator { get; set; }
        public virtual LibUser? Modifier { get; set; }
        public virtual ICollection<LibCallCard> LibCallCards { get; set; }
    }
}
