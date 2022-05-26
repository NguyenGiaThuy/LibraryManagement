using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("LibMemberships")]
    public class LibMembership
    {
        public LibMembership()
        {
            LibCallCards = new HashSet<LibCallCard>();
            LibMembers = new HashSet<LibMember>();
        }

        [Key]
        [StringLength(15)]
        public string MembershipId { get; set; } = null!;
        public DateOnly? ExpiryDate { get; set; }
        [Range(0, int.MaxValue)]
        public int? BorrowLimit { get; set; }
        [Range(0, 1)]
        public int? MembershipType { get; set; }
        [Range(0, 1)]
        public int? Status { get; set; }
        [ForeignKey("Member")]
        [Required]
        public string MemberId { get; set; } = null!;
        [ForeignKey("Creator")]
        [Required]
        public string? CreatorId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual LibMember? Member { get; set; }
        public virtual LibUser? Creator { get; set; }
        public virtual ICollection<LibCallCard> LibCallCards { get; set; }
        public virtual ICollection<LibMember> LibMembers { get; set; }
    }
}
