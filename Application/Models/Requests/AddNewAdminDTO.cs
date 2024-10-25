using Domain.Models.Users;

namespace Application.Models.Requests
{
    public class AddNewAdminDTO
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public static AddNewAdminDTO Create(Admin admin)
        {
            return new AddNewAdminDTO
            {
                UserName = admin.UserName,
                Password = admin.Password,
                Email = admin.Email,
            };
        }
    }
}





