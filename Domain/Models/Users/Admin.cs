using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users
{
    public class Admin : User
    {
        public Admin(string userName, string email, string password, string userType) : base(userName, email, password, userType)
        {
            UserName = userName;
            UserType = "admin";
            Email = email;
            Password = password;
        }
    }
}
