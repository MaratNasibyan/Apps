using Microsoft.AspNetCore.Identity;

namespace Authentication.Server.Entities
{
    public class ApplicationUserToken : IdentityUserToken<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
