using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("LibMembers")]
    public class LibMember
    {
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

        [Key]
        [StringLength(10)]
        public string MemberId { get; set; } = null!;
        [StringLength(12)]
        [Required]
        public string SocialId { get; set; } = null!;
        public string? Name { get; set; }
        public DateTime? Dob { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z")]
        public string? Email { get; set; }
        [ForeignKey("Membership")]
        public string? MembershipId { get; set; }
        [ForeignKey("Creator")]
        public string? CreatorId { get; set; }
        public DateTime? CreatedDate { get; set; }
        [ForeignKey("Modifier")]
        public string? ModifierId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ImageUrl { get; set; }

        public virtual LibUser? Creator { get; set; }
        public virtual LibUser? Modifier { get; set; }
        public virtual LibMembership? Membership { get; set; }
    }
}
