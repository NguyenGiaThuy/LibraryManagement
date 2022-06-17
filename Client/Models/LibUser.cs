using System;
using System.ComponentModel;

namespace Client.Models
{
    public class LibUser
    {
        public enum UserEducation
        {
            [Description("Phổ thông")]
            HighschoolDegree,
            [Description("Trung cấp")]
            IntermediateDegree,
            [Description("Cao đẳng")]
            CollegeDegree,
            [Description("Đại học")]
            BachelorDegree,
            [Description("Thạc sĩ")]
            MasterDegree,
            [Description("Tiến sĩ")]
            PhDDegree
        }
        public string GetEducationDescription(UserEducation userEducation) {
            var type = typeof(UserEducation);
            var member = type.GetMember(userEducation.ToString());
            var attr = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)attr[0]).Description;
        }

        public enum UserDepartment
        {
            [Description("Thủ thư")]
            Librarian,
            [Description("Thủ kho")]
            Storekeeper,
            [Description("Thủ quỹ")]
            Treasurer,
            [Description("Ban giám đốc")]
            Administrator,
            [Description("Lập trình viên")]
            Developer
        }
        public string GetDepartmentDescription(UserDepartment userDepartment) {
            var type = typeof(UserDepartment);
            var member = type.GetMember(userDepartment.ToString());
            var attr = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)attr[0]).Description;
        }

        public enum UserPosition
        {
            [Description("Giám đốc")]
            Director,
            [Description("Phó giám đốc")]
            ViceDirector,
            [Description("Trưởng phòng")]
            Manager,
            [Description("Phó phòng")]
            ViceManager,
            [Description("Nhân viên")]
            Clerk
        }
        public string GetPositionDescription(UserPosition userPosition) {
            var type = typeof(UserPosition);
            var member = type.GetMember(userPosition.ToString());
            var attr = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)attr[0]).Description;
        }

        public enum UserStatus
        {
            [Description("Khả dụng")]
            Active,
            [Description("Không khả dụng")]
            Inactive
        }
        public string GetStatusDescription(UserStatus userStatus) {
            var type = typeof(UserStatus);
            var member = type.GetMember(userStatus.ToString());
            var attr = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)attr[0]).Description;
        }

        public LibUser() {}

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
        public string? EducationDescription {
            get {
                if (Education == null) return "";
                else return GetEducationDescription((UserEducation)Education);
            }
        }
        public UserDepartment? Department { get; set; }
        public string? DepartmentDescription {
            get {
                if (Department == null) return "";
                else return GetDepartmentDescription((UserDepartment)Department);
            }
        }
        public UserPosition? Position { get; set; }
        public string? PositionDescription {
            get {
                if (Position == null) return "";
                else return GetPositionDescription((UserPosition)Position);
            }
        }
        public UserStatus? Status { get; set; }
        public string? StatusDescription {
            get {
                if (Position == null) return "";
                else return GetStatusDescription((UserStatus)Status);
            }
        }
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
            this.Status = libUser.Status;
        }
    }
}
