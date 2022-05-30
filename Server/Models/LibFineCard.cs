using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("LibFineCards")]
    public class LibFineCard
    {
        public LibFineCard(string callCardId, string? creatorId)
        {
            CallCardId = callCardId;
            Status = 0;
            CreatorId = creatorId;
            CreatedDate = DateTime.Now;
            FineCardId = string.Concat("FINE", (CallCardId + CreatedDate.ToString()).GetHashCode().ToString().AsSpan(1, 6));
        }

        [Key]
        [StringLength(10)]
        public string FineCardId { get; set; } = null!;
        [Range(0, int.MaxValue)]
        public int? Arrears { get; set; }
        [Range(0, int.MaxValue)]
        public int? DaysInArrears { get; set; }
        [ForeignKey("CallCard")]
        [Required]
        public string CallCardId { get; set; }
        [Range(0, 1)]
        public int? Reason { get; set; }
        [Range(0, 1)]
        public int? Status { get; set; }
        [ForeignKey("Creator")]
        public string? CreatorId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual LibCallCard? CallCard { get; set; } = null!;
        public virtual LibUser? Creator { get; set; }
    }
}
