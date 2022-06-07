using System;
using System.Collections.Generic;

namespace Client.Models
{
    public class LibBook
    {
        public enum BookGenre
        {
            ComputerScience,
            Mathematics,
            Novel
        }

        public enum BookStatus
        {
            Available,
            Unavailable
        }

        public LibBook() { }

        public LibBook(string isbn, string? title, int? genre, string? author, string? publisher,
            DateTime? publishedDate, int? price, string? receiverId, string? imageUrl)
        {
            LibBookAuditCards = new HashSet<LibBookAuditCard>();
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


        public string BookId { get; set; } = null!;
        public string Isbn { get; set; }
        public string? Title { get; set; }
        public int? Genre { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int? Price { get; set; }
        public int? Status { get; set; }
        public string? ReceiverId { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? ModifierId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ImageUrl { get; set; }

        public virtual LibUser? Receiver { get; set; }
        public virtual LibUser? Modifier { get; set; }
        public virtual ICollection<LibBookAuditCard> LibBookAuditCards { get; set; }
        public virtual ICollection<LibCallCard> LibCallCards { get; set; }

        public void CopyFrom(LibBook libBook)
        {
            this.Isbn = libBook.Isbn;
            this.Title = libBook.Title;
            this.Genre = libBook.Genre;
            this.Author = libBook.Author;
            this.Publisher = libBook.Publisher;
            this.PublishedDate = libBook.PublishedDate;
            this.Price = libBook.Price;
            this.ReceiverId = libBook.ReceiverId;
        }
    }
}
