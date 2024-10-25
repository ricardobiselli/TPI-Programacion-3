using Domain.Models.Users;

namespace Application.Models
{
    public class ShowAdminDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public static ShowAdminDto Create(Admin admin)
        {
            return new ShowAdminDto
            {
                Id = admin.Id,
                UserName = admin.UserName,
                Email = admin.Email

            };
        }
    }
}
