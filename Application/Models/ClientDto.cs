using Domain.Models.Users;


namespace Application.Models
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DniNumber { get; set; }
        public string? Address { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        

        public static ClientDTO Create(Client client)
        {
            return new ClientDTO
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                DniNumber = client.DniNumber,
                Address = client.Address,
                UserName = client.UserName,
                Email = client.Email,
                
            };
        }
    }
}