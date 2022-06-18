using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Client.Models
{
    public class LibBook
    {
        public enum BookGenre
        {
            [Description("Khoa học máy tính")]
            ComputerScience,
            [Description("Toán học")]
            Mathematics,
            [Description("Tiểu thuyết")]
            Novel
        }
        public string GetGenreDescription(BookGenre bookGenre) {
            var type = typeof(BookGenre);
            var member = type.GetMember(bookGenre.ToString());
            var attr = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)attr[0]).Description;
        }

        public enum BookStatus
        {
            [Description("Khả dụng")]
            Available,
            [Description("Không khả dụng")]
            Unavailable
        }
        public string GetStatusDescription(BookStatus bookStatus) {
            var type = typeof(BookStatus);
            var member = type.GetMember(bookStatus.ToString());
            var attr = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)attr[0]).Description;
        }


        public LibBook() {}

        public LibBook(string isbn, string? title, BookGenre? genre, string? author, string? publisher,
            DateTime? publishedDate, int? price, string? receiverId, string? imageUrl)
        {
            Isbn = isbn;
            Title = title;
            Genre = genre;
            Author = author;
            Publisher = publisher;
            PublishedDate = publishedDate;
            Price = price;
            Status = (int)LibBook.BookStatus.Available;
            ReceiverId = receiverId;
            ReceivedDate = DateTime.Now;
            ImageUrl = imageUrl;
            BookId = string.Concat("BOOK", (Isbn + ReceivedDate.ToString()).GetHashCode().ToString().AsSpan(1, 6));
        }


        public string BookId { get; set; } = null!;
        public string Isbn { get; set; }
        public string? Title { get; set; }
        public BookGenre? Genre { get; set; }
        public string? GenreDescription {
            get {
                if (Genre == null) return "";
                else return GetGenreDescription((BookGenre)Genre);
            }
        }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int? Price { get; set; }
        public BookStatus? Status { get; set; }
        public string? StatusDescription {
            get {
                if (Status == null) return "";
                else return GetStatusDescription((BookStatus)Status);
            }
        }
        public string? ReceiverId { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? ModifierId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ImageUrl { get; set; }

        public void CopyFrom(LibBook libBook)
        {
            this.BookId = libBook.BookId;
            this.Isbn = libBook.Isbn;
            this.Title = libBook.Title;
            this.Genre = libBook.Genre;
            this.Author = libBook.Author;
            this.Publisher = libBook.Publisher;
            this.PublishedDate = libBook.PublishedDate;
            this.Price = libBook.Price;
            this.ReceiverId = libBook.ReceiverId;
            this.ReceivedDate = libBook.ReceivedDate;
            this.ModifierId = libBook.ModifierId;
            this.ModifiedDate = libBook.ModifiedDate;
            this.Status = libBook.Status;
            this.ImageUrl = libBook.ImageUrl;
        }
    }
}
