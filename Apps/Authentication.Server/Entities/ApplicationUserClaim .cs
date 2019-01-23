using Microsoft.AspNetCore.Identity;

namespace Authentication.Server.Entities
{
    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
