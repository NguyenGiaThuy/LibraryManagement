using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Ibsn { get; set; } = null!;
        public string? Title { get; set; }
    }
}
