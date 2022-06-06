using Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Views.Login
{
    internal class Credential
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public LibUser.UserDepartment DepartmentCode { get; set; }
        public LibUser.UserStatus StatusCode { get; set; }
    }
}
