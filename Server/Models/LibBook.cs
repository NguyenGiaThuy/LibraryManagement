using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class LibBook
    {
        public LibBook()
        {
            LibBookManagementCards = new HashSet<LibBookManagementCard>();
            LibCallCards = new HashSet<LibCallCard>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string Isbn { get; set; } = null!;
        public int? Genre { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublishedDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? Receiver { get; set; }
        public int? Price { get; set; }
        public int? Status { get; set; }

        public virtual LibUser? ReceiverNavigation { get; set; }
        public virtual ICollection<LibBookManagementCard> LibBookManagementCards { get; set; }
        public virtual ICollection<LibCallCard> LibCallCards { get; set; }
    }
}
