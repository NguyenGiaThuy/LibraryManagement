using System;

namespace Client.Models
{
    public enum FineCardStatus
    {
        NotPaid,
        Paid
    }

    public enum FineCardReason
    {
        Due,
        Lost
    }

    public class LibFineCard
    {
        public LibFineCard() { }

        public LibFineCard(string callCardId, string? creatorId)
        {
            CallCardId = callCardId;
            Status = 0;
            CreatorId = creatorId;
            CreatedDate = DateTime.Now;
            FineCardId = string.Concat("FINE", (CallCardId + CreatedDate.ToString()).GetHashCode().ToString().AsSpan(1, 6));
        }

        public string FineCardId { get; set; } = null!;
        public int? Arrears { get; set; }
        public int? DaysInArrears { get; set; }
        public string CallCardId { get; set; }
        public int? Reason { get; set; }
        public int? Status { get; set; }
        public string? CreatorId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual LibCallCard? CallCard { get; set; } = null!;
        public virtual LibUser? Creator { get; set; }

        public void CopyFrom(LibFineCard libFineCard)
        {
            this.FineCardId = libFineCard.FineCardId;
            this.Arrears = libFineCard.Arrears;
            this.DaysInArrears = libFineCard.DaysInArrears;
            this.CallCardId = libFineCard.CallCardId;
            this.Reason = libFineCard.Reason;
            this.Status = libFineCard.Status;
            this.CreatorId = libFineCard.CreatorId;
            this.CreatedDate = libFineCard.CreatedDate;
        }
    }
}
