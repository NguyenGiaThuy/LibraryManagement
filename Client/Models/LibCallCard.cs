using System;
using System.ComponentModel;

namespace Client.Models
{
    public class LibCallCard
    {
        public enum CallCardStatus
        {
            [Description("Đang mượn")]
            Borrowing,
            [Description("Đã trả")]
            Returned,
            [Description("Tới hạn")]
            Due,
            [Description("Mất")]
            Lost
        }
        public string GetStatusDescription(CallCardStatus callCardStatus) {
            var type = typeof(CallCardStatus);
            var member = type.GetMember(callCardStatus.ToString());
            var attr = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)attr[0]).Description;
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
        public CallCardStatus? Status { get; set; }
        public string? StatusDescription {
            get {
                if (Status == null) return "";
                else return GetStatusDescription((CallCardStatus)Status);
            }
        }
        public string? CreatorId { get; set; }
        public DateTime? CreatedDate { get; set; }

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
