using Domain.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class AddClientDTO
    {
        [StringLength(20, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 20 characters.")]

        public string? FirstName { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 20 characters.")]

        public string? LastName { get; set; }
        [RegularExpression(@"^\d{8,9}$", ErrorMessage = "DNI number must be 8 or 9 digits.")]
        public string? DniNumber { get; set; }
        public string? Address { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters.")]
        public string? UserName { get; set; }
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Password must be at least 3 characters long.")]
        public string? Password { get; set; }


        public static AddClientDTO Create(Client client)
        {
            return new AddClientDTO
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                DniNumber = client.DniNumber,
                Address = client.Address,
                UserName = client.UserName,
                Email = client.Email,
                Password = client.Password,

            };
        }
    }
}
