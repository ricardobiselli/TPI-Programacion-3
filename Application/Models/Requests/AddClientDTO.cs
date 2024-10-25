using Domain.Models.Users;

namespace Application.Models.Requests
{
    public class AddClientDTO
    {
        //public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DniNumber { get; set; }
        public string? Address { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
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
