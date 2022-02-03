using System;
using System.Collections.Generic;

namespace ServerLangUp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Rating { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<UserTest> UserTests { get; set; }
    }
}
