﻿using Domain.Models.Purchases;

namespace Domain.Models.Users
{
    public class Client : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DniNumber { get; set; }
        public string Address { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public Client(string userName, string email, string password, string firstName, string lastName, string dniNumber, string address)
            : base(userName, email, password, "client")
        {
            FirstName = firstName;
            LastName = lastName;
            DniNumber = dniNumber;
            Address = address;
            Orders = new List<Order>();
            ShoppingCart = new ShoppingCart()
            {
                Client = this
            };
        }

    }
}