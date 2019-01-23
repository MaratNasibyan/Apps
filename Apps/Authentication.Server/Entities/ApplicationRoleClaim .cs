using Microsoft.AspNetCore.Identity;

namespace Authentication.Server.Entities
{
    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public virtual ApplicationRole Role { get; set; }
    }
}
