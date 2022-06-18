using System;
using System.ComponentModel;

namespace Client.Models
{
    public class LibMember
    {
        public LibMember() { }

        public LibMember(string socialId, string? name, DateTime? dob, string? address, string? mobile, string? email, string? creatorId, string? imageUrl)
        {
            SocialId = socialId;
            Name = name;
            Dob = dob;
            Address = address;
            Mobile = mobile;
            Email = email;
            CreatorId = creatorId;
            CreatedDate = DateTime.Now;
            ImageUrl = imageUrl;
            MemberId = string.Concat("MEMB", (SocialId + CreatedDate.ToString()).GetHashCode().ToString().AsSpan(1, 6));
        }

        public string MemberId { get; set; } = null!;
        public string SocialId { get; set; }
        public string? Name { get; set; }
        public DateTime? Dob { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? MembershipId { get; set; }
        public string? CreatorId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifierId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ImageUrl { get; set; }

        public void CopyFrom(LibMember libMember) {
            this.MemberId = libMember.MemberId;
            this.SocialId = libMember.SocialId;
            this.Name = libMember.Name;
            this.Dob = libMember.Dob;
            this.Address = libMember.Address;
            this.Mobile = libMember.Mobile;
            this.Email = libMember.Email;
            this.MembershipId = libMember.MembershipId;
            this.CreatorId = libMember.CreatorId;
            this.CreatedDate = libMember.CreatedDate;
            this.ModifierId = libMember.ModifierId;
            this.ModifiedDate = libMember.ModifiedDate;
            this.ImageUrl = libMember.ImageUrl;
        }
    }
}
