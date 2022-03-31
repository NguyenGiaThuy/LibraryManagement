using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class LibUser
    {
        public LibUser()
        {
            LibBookManagementCards = new HashSet<LibBookManagementCard>();
            LibBooks = new HashSet<LibBook>();
            LibCallCards = new HashSet<LibCallCard>();
            LibMemberships = new HashSet<LibMembership>();
        }

        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }
        public string? Mobile { get; set; }
        public int? Education { get; set; }
        public int? Department { get; set; }
        public int? Position { get; set; }

        public virtual ICollection<LibBookManagementCard> LibBookManagementCards { get; set; }
        public virtual ICollection<LibBook> LibBooks { get; set; }
        public virtual ICollection<LibCallCard> LibCallCards { get; set; }
        public virtual ICollection<LibMembership> LibMemberships { get; set; }
    }
}
