using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class LibCallCard
    {
        public int Id { get; set; }
        public int? Type { get; set; }
        public string? Isbn { get; set; }
        public string? MembershipId { get; set; }
        public string? MembershipName { get; set; }
        public int? ArrearAmount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CurrentDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? Creator { get; set; }
        public int? Status { get; set; }

        public virtual LibUser? CreatorNavigation { get; set; }
        public virtual LibBook? IsbnNavigation { get; set; }
        public virtual LibMembership? Membership { get; set; }
    }
}
