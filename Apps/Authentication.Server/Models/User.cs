using Microsoft.AspNetCore.Identity;

namespace Authentication.Server.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
