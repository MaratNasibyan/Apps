using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Server.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<ApplicationUserClaim> UserClaims { get; set; }
        public virtual ICollection<ApplicationUserLogin> UserLogins { get; set; }
        public virtual ICollection<ApplicationUserToken> UserTokens { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public string FirstName { get; set; }
    }
}
