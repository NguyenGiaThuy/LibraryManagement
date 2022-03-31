using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class LibMember
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Dob { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? MembershipId { get; set; }

        public virtual LibMembership? Membership { get; set; }
    }
}
