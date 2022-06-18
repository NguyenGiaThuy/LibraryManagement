using System;
using System.ComponentModel;

namespace Client.Models
{
    public class LibBookAuditCard
    {
        public enum BookAuditCardType
        {
            [Description("Thêm")]
            Add,
            [Description("Cập nhật")]
            Update,
            [Description("Xóa")]
            Remove
        }
        public string GetTypeDescription(BookAuditCardType bookAuditCardType) {
            var type = typeof(BookAuditCardType);
            var member = type.GetMember(bookAuditCardType.ToString());
            var attr = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)attr[0]).Description;
        }

        public enum BookAuditCardReason
        {
            [Description("Mất")]
            Lost,
            [Description("Hư hỏng")]
            Damaged,
            [Description("Người dùng làm mất")]
            LostByMember
        }
        public string GetReasonDescription(BookAuditCardReason bookAuditCardReason) {
            var type = typeof(BookAuditCardReason);
            var member = type.GetMember(bookAuditCardReason.ToString());
            var attr = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)attr[0]).Description;
        }

        public LibBookAuditCard() { }

        public LibBookAuditCard(string bookId, BookAuditCardType? type, BookAuditCardReason? reason, string? creatorId)
        {
            BookId = bookId;
            CreatedDate = DateTime.Now;
            Type = type;
            Reason = reason;
            CreatorId = creatorId;
            BookAuditCardId = string.Concat("AUDI", (BookId + CreatedDate.ToString()).GetHashCode().ToString().AsSpan(1, 6));
        }

        public string BookAuditCardId { get; set; } = null!;
        public string BookId { get; set; }
        public BookAuditCardType? Type { get; set; }
        public string? TypeDescription {
            get {
                if (Type == null) return "";
                else return GetTypeDescription((BookAuditCardType)Type);
            }
        }
        public BookAuditCardReason? Reason { get; set; }
        public string? ReasonDescription {
            get {
                if (Reason == null) return "";
                else return GetReasonDescription((BookAuditCardReason)Reason);
            }
        }
        public string? CreatorId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
