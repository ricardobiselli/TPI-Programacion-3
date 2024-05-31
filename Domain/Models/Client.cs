using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Client(string userName, string email, string password, string userType, string firstName, string lastName, string dniNumber, string address, int zipCode, string phoneNumber) : User(userName, email, password, userType)
    {
        public int ClientId { get; set; }
        public string? FirstName { get; set; } = firstName;
        public string? LastName { get; set; } = lastName;
        public string? DniNumber { get; set; } = dniNumber;
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public string? Address { get; set; } = address;
        public int ZipCode { get; set; } = zipCode;
        public string? PhoneNumber { get; set; } = phoneNumber;
        public List<Order> Orders { get; set; } = [];


    }
}
