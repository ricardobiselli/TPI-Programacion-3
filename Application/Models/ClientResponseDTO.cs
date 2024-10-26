using Domain.Models.Users;

namespace Application.Models
{
    public class ClientResponseDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public static ClientResponseDTO Create(Client client)
        {
            return new ClientResponseDTO
            {
                UserName = client.UserName,
                Email = client.Email,

            };
        }

    }
}
