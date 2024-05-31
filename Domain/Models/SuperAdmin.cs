using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SuperAdmin(string userName, string email, string password, string userType) : AdminClass(userName, email, password, userType)
    {
    }
}
