using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Application.Models
{
    public class ClientDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DniNumber { get; set; }
        public string? Address { get; set; }
        public string? UserName { get; set; }
        public string? Email {  get; set; }
        public string? Password { get; set; }
        public List<OrderDTO>? Orders { get; set; }
        public ShoppingCartDto? ShoppingCart { get; set; }

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
                Orders = client.Orders.Select(OrderDTO.Create).ToList(),
                ShoppingCart = ShoppingCartDto.Create(client.ShoppingCart)
            };
        }
    }
}