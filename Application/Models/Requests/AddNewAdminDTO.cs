using Domain.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class AddNewAdminDTO
    {
        [Required(ErrorMessage = "Username field is required")]
        [StringLength(20, MinimumLength = 3)]

        public string UserName { get; set; }
        [Required(ErrorMessage = "Password field is required")]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email field is required")]
        [EmailAddress]
        [RegularExpression(@"[^@\s]+@[^@\s]+\.[^@\s]+$",ErrorMessage = "invalid mail format")]
        public string Email { get; set; }

        
    }
}





