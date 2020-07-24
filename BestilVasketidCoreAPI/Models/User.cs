using System;

namespace BestilVasketidCoreAPI.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Changed { get; set; }
        public DateTime? Deleted { get; set; }

    }

    [Serializable]
    public class LoginUser 
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginUser(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public LoginUser()
        {
                
        }
    }
}
