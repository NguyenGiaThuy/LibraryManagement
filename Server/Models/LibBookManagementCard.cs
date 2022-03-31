using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class LibBookManagementCard
    {
        public int Id { get; set; }
        public int? Type { get; set; }
        public string? Isbn { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Creator { get; set; }

        public virtual LibUser? CreatorNavigation { get; set; }
        public virtual LibBook? IsbnNavigation { get; set; }
    }
}
