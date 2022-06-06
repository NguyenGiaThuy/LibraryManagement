using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models {
    public class LibUser {
        public enum UserEducation
        {
            HighschoolDegree,
            IntermediateDegree,
            CollegeDegree,
            BachelorDegree,
            MasterDegree,
            PhDDegree
        }

        public enum UserDepartment
        {
            Librarian,
            Storekeeper,
            Treasurer,
            Administrator,
            Developer
        }

        public enum UserPosition
        {
            Director,
            ViceDirector,
            Manager,
            ViceManager,
            Clerk
        }

        public enum UserStatus
        {
            Active,
            Inactive
        }

        public LibUser() { }

        public LibUser(string userId, string password, string? name, string? address,
            DateTime? dob, string? mobile, int? education, int? department, int? position, string? imageUrl) {
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
        public string UserId { get; set; } = null!;
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }
        public string? Mobile { get; set; }
        public int? Education { get; set; }
        public int? Department { get; set; }
        public int? Position { get; set; }
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

        public void CopyFrom(LibUser libUser) {
            this.UserId = libUser.UserId;
            this.Password = libUser.Password;
            this.Name = libUser.Name;
            this.Address = libUser.Address;
            this.Dob = libUser.Dob;
            this.Mobile = libUser.Mobile;
            this.Education = libUser.Education;
            this.Department = libUser.Department;
            this.Position = libUser.Position;
        }
    }
}
