using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Users
{
    public abstract class User
    {

        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public EntitiesState State { get; set; } = EntitiesState.Active;

        public User()
        {
        }
        public User(string userName, string email, string password, string userType)
        {
            UserName = userName;
            Email = email;
            Password = password;
            UserType = userType;
            State = EntitiesState.Active;
        }
    }
}
