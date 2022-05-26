using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;

namespace Client {
    public class Book {
        public string BookId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int Genre { get; set; } //{0,1,2}
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ReceiverId { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int Price { get; set; }
        public int Status { get; set; } //{0,1}
        public string ImgSource { get; set; }

        public Book() { }

        public Book(string bookId, string isbn, string title, int genre, string author, string publisher, DateTime publishedDate, string receiverId, DateTime receiverDate, string modifierId, DateTime modifiedDate, int price, int status, string imgSource) {
            this.BookId = bookId;
            this.ISBN = isbn;
            this.Title = title;
            this.Genre = genre;
            this.Author = author;
            this.Publisher = publisher;
            this.PublishedDate = publishedDate;
            this.ReceiverId = receiverId;
            this.ReceivedDate = receiverDate;
            this.ModifierId = modifierId;
            this.ModifiedDate = modifiedDate;
            this.Price = price;
            this.Status = status;
            this.ImgSource = imgSource;
        }

        public void CopyFrom(Book book) {
            this.BookId = book.BookId;
            this.ISBN = book.ISBN;
            this.Title = book.Title;
            this.Genre = book.Genre;
            this.Author = book.Author;
            this.Publisher = book.Publisher;
            this.PublishedDate = book.PublishedDate;
            this.ReceiverId = book.ReceiverId;
            this.ReceivedDate = book.ReceivedDate;
            this.ModifierId = book.ModifierId;
            this.ModifiedDate = book.ModifiedDate;
            this.Price = book.Price;
            this.Status = book.Status;
        }
    }

    public class User {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public int Education { get; set; } //{0,1,2,3,4}
        public int Department { get; set; } //{0,1,2,3}
        public int Position { get; set; } //{0,1,2,3,4}
        public int Status { get; set; } //{0,1}

        public User(string userId, string password, string name, string address, DateTime dateOfBirth, string mobile, int education, int department, int position, int status) {
            this.UserId = userId;
            this.Password = password;
            this.Name = name;
            this.Address = address;
            this.DateOfBirth = dateOfBirth;
            this.Mobile = mobile;
            this.Education = education;
            this.Department = department;
            this.Position = position;
            this.Status = status;
        }
    }

    public class Member {
        public string MemberId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string MembershipId { get; set; }
        public string ModifierID { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Member(string memberId, string name, DateTime dateOfBirth, string address, string mobile, string email, DateTime createdDate, string membershipId, string modifierId, DateTime modifiedDate) {
            this.MemberId = memberId;
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
            this.Address = address;
            this.Mobile = mobile;
            this.Email = email;
            this.CreatedDate = createdDate;
            this.MemberId = memberId;
            this.ModifierID = modifierId;
            this.ModifiedDate = modifiedDate;
        }
    }

    public class Membership {
        public string MembershipId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int BorrowLimit { get; set; }
        public int MembershipType { get; set; } //{0,1}
        public int Status { get; set; } //{0,1}

        public Membership(string membershipId, DateTime createdDate, DateTime expiryDate, int borrowLimit, int membershipType, int status) {
            this.MembershipId = membershipId;
            this.CreatedDate = createdDate;
            this.ExpiryDate = expiryDate;
            this.BorrowLimit = borrowLimit;
            this.MembershipType = membershipType;
            this.Status = status;
        }
    }

    public class CallCard {
        public string CallCardId { get; set; }
        public string BookId { get; set; }
        public string MembershipId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public string CreatorId { get; set; }
        public int Status { get; set; } //{0,1,2,3}

        public CallCard(string callCardId, string bookId, string membershipId, DateTime createdDate, DateTime dueDate, string creatorId, int status) {
            this.CallCardId = callCardId;
            this.BookId = bookId;
            this.MembershipId = membershipId;
            this.CreatedDate = createdDate;
            this.DueDate = dueDate;
            this.CreatorId = creatorId;
            this.Status = status;
        }
    }

    public class FineCard {
        public string FineCardId { get; set; }
        public string CallCardId { get; set; }
        public int ArrearAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatorId { get; set; }
        public int DaysInArrear { get; set; }
        public int Reason { get; set; } //{0,1}
        public int Status { get; set; } //{0,1}

        public FineCard(string fineCardId, string CallCardId, int arrearAmount, DateTime createdDate, string creatorId, int daysInArrear, int reason, int status) {
            this.FineCardId = fineCardId;
            this.CallCardId = CallCardId;
            this.ArrearAmount = arrearAmount;
            this.CreatedDate = createdDate;
            this.CreatorId = creatorId;
            this.DaysInArrear = daysInArrear;
            this.Reason = reason;
            this.Status = status;
        }
    }

    public class BookAuditCard {
        public string BookAuditCardId { get; set; }
        public string BookId { get; set; }
        public int Type { get; set; } //{0,1,2}
        public DateTime CreatedDate { get; set; }
        public string CreatorId { get; set; }

        public BookAuditCard(string bookAuditCardId, string bookId, int type, DateTime createdDate, string creatorId) {
            this.BookAuditCardId = bookAuditCardId;
            this.BookId = bookId;
            this.Type = type;
            this.CreatedDate = createdDate;
            this.CreatorId = creatorId;
        }
    }
}