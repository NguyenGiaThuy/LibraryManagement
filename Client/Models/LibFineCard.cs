using System;
using System.ComponentModel;

namespace Client.Models
{
    public class LibFineCard
    {
        public enum FineCardStatus {
            [Description("Chưa trả tiền")]
            NotPaid,
            [Description("Đã trả tiền")]
            Paid
        }
        public string GetStatusDescription(FineCardStatus fineCardStatus) {
            var type = typeof(FineCardStatus);
            var member = type.GetMember(fineCardStatus.ToString());
            var attr = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)attr[0]).Description;
        }

        public enum FineCardReason {
            [Description("Tới hạn")]
            Due,
            [Description("Đã mất")]
            Lost
        }
        public string GetReasonDescription(FineCardReason fineCardReason) {
            var type = typeof(FineCardReason);
            var member = type.GetMember(fineCardReason.ToString());
            var attr = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)attr[0]).Description;
        }

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
        public FineCardReason? Reason { get; set; }
        public string? ReasonDescription {
            get {
                if (Reason == null) return "";
                else return GetReasonDescription((FineCardReason)Reason);
            }
        }
        public FineCardStatus? Status { get; set; }
        public string? StatusDescription {
            get {
                if (Status == null) return "";
                else return GetStatusDescription((FineCardStatus)Status);
            }
        }
        public string? CreatorId { get; set; }
        public DateTime? CreatedDate { get; set; }

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
