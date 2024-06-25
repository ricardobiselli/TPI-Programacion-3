using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users
{
    public class SuperAdmin: Admin
    {
        public SuperAdmin(string userName, string email, string password, string userType) : base(userName, email, password, userType)
        {
            UserName = UserName;
            Email = Email;
            Password = Password;
            UserType = "superadmin";
        }
    }
}
