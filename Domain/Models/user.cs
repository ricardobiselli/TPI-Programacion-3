using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Models
{
    public abstract class User(string userName, string email, string password, string userType)


    {
        public int Id { get; set; }

        public string? UserName { get; set; } = userName;
        public string? Email { get; set; } = email;
        public string Password { get; set; } = password;
        public string UserType { get; set; } = userType;
    }
}
