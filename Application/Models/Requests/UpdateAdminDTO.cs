using Domain.Models.Users;

namespace Application.Models.Requests
{
    public class UpdateAdminDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public static UpdateAdminDTO Create(Admin admin)
        {
            return new UpdateAdminDTO
            {
                Id = admin.Id,
                UserName = admin.UserName,
                Email = admin.Email,
                Password = admin.Password
            };
        }
    }
}
