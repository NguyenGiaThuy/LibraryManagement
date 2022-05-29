using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("LibBooks")]
    public class LibBook
    {
        public LibBook(string isbn, string? title, int? genre, string? author, string? publisher,
            DateTime? publishedDate, int? price, string? receiverId, string? imageUrl)
        {
            LibBookAuditCards = new HashSet<LibFineCard>();
            LibCallCards = new HashSet<LibCallCard>();

            Isbn = isbn;
            Title = title;
            Genre = genre;
            Author = author;
            Publisher = publisher;
            PublishedDate = publishedDate;
            Price = price;
            Status = 0;
            ReceiverId = receiverId;
            ReceivedDate = DateTime.Now;
            ImageUrl = imageUrl;
            BookId = string.Concat("BOOK", (Isbn + ReceivedDate.ToString()).GetHashCode().ToString().AsSpan(1, 6));
        }

        [Key]
        [StringLength(10)]
        public string BookId { get; set; } = null!;
        [StringLength(13)]
        public string Isbn { get; set; } = null!;
        public string? Title { get; set; }
        [Range(0, 2)]
        public int? Genre { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublishedDate { get; set; }
        [Range(0, int.MaxValue)]
        public int? Price { get; set; }
        [Range(0, 1)]
        public int? Status { get; set; }
        [ForeignKey("Receiver")]
        public string? ReceiverId { get; set; }
        public DateTime? ReceivedDate { get; set; }
        [ForeignKey("Modifier")]
        public string? ModifierId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ImageUrl { get; set; }

        public virtual LibUser? Receiver { get; set; }
        public virtual LibUser? Modifier { get; set; }
        public virtual ICollection<LibFineCard> LibBookAuditCards { get; set; }
        public virtual ICollection<LibCallCard> LibCallCards { get; set; }
    }
}
