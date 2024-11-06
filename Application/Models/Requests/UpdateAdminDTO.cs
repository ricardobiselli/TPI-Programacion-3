using Domain.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class UpdateAdminDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username  is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters.")]
        public string UserName { get; set; }

        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
        [EmailAddress]
        [Required(ErrorMessage = "Email  is required")]
        public string Email { get; set; }

       
    }
}

