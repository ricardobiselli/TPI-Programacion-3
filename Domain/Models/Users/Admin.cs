namespace Domain.Models.Users
{


    public class Admin : User
    {
        public Admin(string userName, string email, string password)
            : base(userName, email, password, "admin") 
        {
        }
    }
}



