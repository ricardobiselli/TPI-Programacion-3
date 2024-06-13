using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users
{
    public class AdminClass(string userName, string email, string password, string userType) : User(userName, email, password, userType)
    {
    }
}
