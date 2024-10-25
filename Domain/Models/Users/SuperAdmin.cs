namespace Domain.Models.Users
{
    public class SuperAdmin : User
    {
        public SuperAdmin(string userName, string email, string password)
            : base(userName, email, password, "superadmin")
        {
        }
    }
}


