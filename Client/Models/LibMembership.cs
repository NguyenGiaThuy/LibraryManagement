using System;
using System.Collections.Generic;

namespace Client.Models
{
    public class LibMembership
    {
        public enum MembershipType
        {
            New,
            Honored
        }

        public enum MembershipStatus
        {
            Active,
            Inactive
        }

        public LibMembership() { }

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

        public string MembershipId { get; set; } = null!;
        public string SocialId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? Type { get; set; }
        public int? Status { get; set; }
        public string MemberId { get; set; }
        public string? CreatorId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifierId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual LibMember? Member { get; set; }
        public virtual LibUser? Creator { get; set; }
        public virtual LibUser? Modifier { get; set; }
        public virtual ICollection<LibCallCard> LibCallCards { get; set; }
    }
}
