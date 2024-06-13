using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Models.Purchases;

namespace Domain.Models.Users
{
    public class Client : User
    {
        public Client(string userName, string email, string password, string userType, string firstName, string lastName, string dniNumber, string address, int zipCode, string phoneNumber)
            : base(userName, email, password, userType)
        {
            FirstName = firstName;
            LastName = lastName;
            DniNumber = dniNumber;
            Address = address;
            //ZipCode = zipCode;
            PhoneNumber = phoneNumber;
            BirthDate = DateTime.Now;
            Orders = new List<Order>();
            Payments = new List<Payment>();
            UserType = "client";
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DniNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Address { get; set; }
        //public int ZipCode { get; set; }
        public string? PhoneNumber { get; set; }

        public ICollection<Order>? Orders { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public ShoppingCart? Cart { get; set; }
    }
}
