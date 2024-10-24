using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Users;

namespace Application.Models
{
    public class AdminDto
    {

        public string UserName { get; set; }
        public string Email { get; set; }

        public static AdminDto Create(Admin admin)
        {
            return new AdminDto
            {
                UserName = admin.UserName,
                Email = admin.Email

            };
        }
    }
}
