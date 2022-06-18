using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Client.Models
{
    public class LibMembership
    {
        public enum MembershipType
        {
            [Description("Độc giả mới")]
            New,
            [Description("Độc giả cao cấp")]
            Honored
        }
        public string GetTypeDescription(MembershipType membershipType) {
            var type = typeof(MembershipType);
            var member = type.GetMember(membershipType.ToString());
            var attr = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)attr[0]).Description;
        }

        public enum MembershipStatus
        {
            [Description("Khả dụng")]
            Active,
            [Description("Không khả dụng")]
            Inactive
        }
        public string GetStatusDescription(MembershipStatus membershipStatus) {
            var type = typeof(MembershipStatus);
            var member = type.GetMember(membershipStatus.ToString());
            var attr = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)attr[0]).Description;
        }

        public LibMembership() { }

        public LibMembership(string memberId, string socialId, string? creatorId)
        {
            MemberId = memberId;
            SocialId = socialId;
            Type = 0;
            Status = 0;
            CreatorId = creatorId;
            CreatedDate = DateTime.Now;
            StartDate = DateTime.Now;
            ExpiryDate = DateTime.Now.AddMonths(6);
            MembershipId = string.Concat("MEMS", (memberId + CreatedDate.ToString()).GetHashCode().ToString().AsSpan(1, 6));
        }

        public string MembershipId { get; set; } = null!;
        public string SocialId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public MembershipType? Type { get; set; }
        public string? TypeDescription {
            get {
                if (Type == null) return "";
                else return GetTypeDescription((MembershipType)Type);
            }
        }
        public MembershipStatus? Status { get; set; }
        public string? StatusDescription {
            get {
                if (Status == null) return "";
                else return GetStatusDescription((MembershipStatus)Status);
            }
        }
        public string MemberId { get; set; }
        public string? CreatorId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifierId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public void CopyFrom(LibMembership libMembership) {
            this.MembershipId = libMembership.MembershipId;
            this.SocialId = libMembership.SocialId;
            this.CreatedDate = libMembership.CreatedDate;
            this.ExpiryDate = libMembership.ExpiryDate;
            this.Type = libMembership.Type;
            this.Status = libMembership.Status;
            this.ModifiedDate = libMembership.ModifiedDate;
            this.ModifierId = libMembership.ModifierId;
            this.MemberId = libMembership.MemberId;
            this.CreatorId = libMembership.CreatorId;
            this.StartDate = libMembership.StartDate;
        }
    }
}
