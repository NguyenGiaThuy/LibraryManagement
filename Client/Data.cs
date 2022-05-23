using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;

namespace Client {
    public class Book {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int Genre { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string ReceiverId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public Book(string isbn, string title, int genre, string author, string publisher, DateTime publishedDate, DateTime receiverDate, string receiverId, int price, int quantity) { 
            this.ISBN = isbn;
            this.Title = title;
            this.Genre = genre;
            this.Author = author;
            this.Publisher = publisher;
            this.PublishedDate = publishedDate;
            this.ReceivedDate = receiverDate;
            this.ReceiverId = receiverId;
            this.Price = price;
            this.Quantity = quantity;
        }
    }
}