using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Users
{
    public abstract class User
    {
        

        public User(string userName, string email, string password, string userType)
        {
            UserName = userName;
            Email = email;
            Password = password;
            UserType = userType;
        }

        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserType { get; set; } 
        public User()
        {
        }
    }
}
