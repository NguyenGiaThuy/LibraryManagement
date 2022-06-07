using System;

namespace Client.Models
{
    public class LibCallCard
    {
        public enum CallCardStatus
        {
            Borrowing,
            Returned,
            Due,
            Lost
        }

        public LibCallCard() { }

        public LibCallCard(string bookId, DateTime? dueDate, string membershipId, string? creatorId)
        {
            BookId = bookId;
            DueDate = dueDate;
            MembershipId = membershipId;
            Status = 0;
            CreatorId = creatorId;
            CreatedDate = DateTime.Now;
            CallCardId = string.Concat("CALL", (BookId + CreatedDate.ToString()).GetHashCode().ToString().AsSpan(1, 6));
        }

        public string CallCardId { get; set; } = null!;
        public DateTime? DueDate { get; set; }
        public string BookId { get; set; }
        public string MembershipId { get; set; }
        public int? Status { get; set; }
        public string? CreatorId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual LibBook? Book { get; set; }
        public virtual LibMembership? Membership { get; set; }
        public virtual LibUser? Creator { get; set; }

        public void CopyFrom(LibCallCard libCallCard)
        {
            this.CallCardId = libCallCard.CallCardId;
            this.DueDate = libCallCard.DueDate;
            this.BookId = libCallCard.BookId;
            this.MembershipId = libCallCard.MembershipId;
            this.Status = libCallCard.Status;
            this.CreatorId = libCallCard.CreatorId;
            this.CreatedDate = libCallCard.CreatedDate;
        }
    }
}
