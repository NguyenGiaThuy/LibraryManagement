using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models {
    public class LibBookAuditCard {
        public enum BookAuditCardType
        {
            Add,
            Update,
            Remove
        }

        public enum BookAuditCardReason
        {
            Lost,
            Damaged,
            LostByMember
        }

        public LibBookAuditCard() { }

        public LibBookAuditCard(string bookId, int? type, int? reason, string? creatorId) {
            BookId = bookId;
            CreatedDate = DateTime.Now;
            Type = type;
            Reason = reason;
            CreatorId = creatorId;
            BookAuditCardId = string.Concat("AUDI", (BookId + CreatedDate.ToString()).GetHashCode().ToString().AsSpan(1, 6));
        }

        public string BookAuditCardId { get; set; } = null!;
        public string BookId { get; set; }
        public int? Type { get; set; }
        public int? Reason { get; set; }
        public string? CreatorId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual LibBook? Book { get; set; }
        public virtual LibUser? Creator { get; set; }

        public void CopyFrom(LibBookAuditCard libBookAuditCard) {
            this.BookAuditCardId = libBookAuditCard.BookAuditCardId;
            this.BookId = libBookAuditCard.BookId;
            this.Type = libBookAuditCard.Type;
            this.Reason = libBookAuditCard.Reason;
            this.CreatorId = libBookAuditCard.CreatorId;
            this.CreatedDate = libBookAuditCard.CreatedDate;
        }
    }
}
