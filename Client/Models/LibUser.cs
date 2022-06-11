using System;
using System.Collections.Generic;

namespace Client.Models
{
    public class LibUser
    {
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
            DateTime? dob, string? mobile, UserEducation? education, UserDepartment? department, UserPosition? position, string? imageUrl)
        {
            UserId = userId;
            Password = password;
            Name = name;
            Address = address;
            Dob = dob;
            Mobile = mobile;
            Education = education;
            Department = department;
            Position = position;
            Status = UserStatus.Active;
            ImageUrl = imageUrl;
        }
        public string UserId { get; set; } = null!;
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }
        public string? Mobile { get; set; }
        public UserEducation? Education { get; set; }
        public UserDepartment? Department { get; set; }
        public UserPosition? Position { get; set; }
        public UserStatus? Status { get; set; }
        public string? ImageUrl { get; set; }

        public void CopyFrom(LibUser libUser)
        {
            this.UserId = libUser.UserId;
            this.Password = libUser.Password;
            this.Name = libUser.Name;
            this.Address = libUser.Address;
            this.Dob = libUser.Dob;
            this.Mobile = libUser.Mobile;
            this.Education = libUser.Education;
            this.Department = libUser.Department;
            this.Position = libUser.Position;
            this.ImageUrl = libUser.ImageUrl;
        }
    }
}
