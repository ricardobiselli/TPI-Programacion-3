using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Models.Purchases;

namespace Domain.Models.Users
{
    public class Client : User
    {
        public Client()
        {
            UserType = "client";
        }

        public Client(string userName, string email, string password, string firstName, string lastName, string dniNumber, string address)
            : base(userName, email, password, "client")
        {
            FirstName = firstName;
            LastName = lastName;
            DniNumber = dniNumber;
            Address = address;
            Orders = new List<Order>();
            Payments = new List<Payment>();
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DniNumber { get; set; }
        public string? Address { get; set; }

        public ICollection<Order>? Orders { get; set; } // one to many
        public ICollection<Payment>? Payments { get; set; } // one to many
        public ShoppingCart? Cart { get; set; } // one to one
    }
}