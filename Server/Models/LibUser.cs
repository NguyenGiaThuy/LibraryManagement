using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("LibUsers")]
    public class LibUser
    {
        public LibUser(string userId, string password, string? name, string? address,
            DateTime? dob, string? mobile, int? education, int? department, int? position, string? imageUrl)
        {
            CreatedLibBooks = new HashSet<LibBook>();
            ModifiedLibBooks = new HashSet<LibBook>();
            CreatedLibCallCards = new HashSet<LibCallCard>();
            CreatedLibFineCards = new HashSet<LibFineCard>();
            CreatedLibBookAuditCards = new HashSet<LibBookAuditCard>();
            CreatedLibMembers = new HashSet<LibMember>();
            ModifiedLibMembers = new HashSet<LibMember>();
            CreatedLibMemberships = new HashSet<LibMembership>();
            ModifiedLibMemberships = new HashSet<LibMembership>();

            UserId = userId;
            Password = password;
            Name = name;
            Address = address;
            Dob = dob;
            Mobile = mobile;
            Education = education;
            Department = department;
            Position = position;
            Status = 0;
            ImageUrl = imageUrl;
        }

        [Key]
        [StringLength(10)]
        public string UserId { get; set; } = null!;
        [StringLength(15)]
        [Required]
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }
        public string? Mobile { get; set; }
        [Range(0, 5)]
        public int? Education { get; set; }
        [Range(0, 4)]
        public int? Department { get; set; }
        [Range(0, 4)]
        public int? Position { get; set; }
        [Range(0, 1)]
        public int? Status { get; set; }
        public string? ImageUrl { get; set; }

        public virtual ICollection<LibBook> CreatedLibBooks { get; set; }
        public virtual ICollection<LibBook> ModifiedLibBooks { get; set; }
        public virtual ICollection<LibCallCard> CreatedLibCallCards { get; set; }
        public virtual ICollection<LibFineCard> CreatedLibFineCards { get; set; }
        public virtual ICollection<LibBookAuditCard> CreatedLibBookAuditCards { get; set; }
        public virtual ICollection<LibMembership> CreatedLibMemberships { get; set; }
        public virtual ICollection<LibMembership> ModifiedLibMemberships { get; set; }
        public virtual ICollection<LibMember> CreatedLibMembers { get; set; }
        public virtual ICollection<LibMember> ModifiedLibMembers { get; set; }
    }
}
