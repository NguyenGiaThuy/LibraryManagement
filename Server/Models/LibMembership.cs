using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class LibMembership
    {
        public LibMembership()
        {
            LibCallCards = new HashSet<LibCallCard>();
            LibMembers = new HashSet<LibMember>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ArrearAmount { get; set; }
        public DateTime? Dob { get; set; }
        public int? DaysInArrear { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string MembershipId { get; set; } = null!;
        public int? MembershipType { get; set; }
        public string? Creator { get; set; }
        public int? Status { get; set; }

        public virtual LibUser? CreatorNavigation { get; set; }
        public virtual ICollection<LibCallCard> LibCallCards { get; set; }
        public virtual ICollection<LibMember> LibMembers { get; set; }
    }
}
