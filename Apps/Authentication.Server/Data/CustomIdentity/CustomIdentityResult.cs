using Microsoft.AspNetCore.Identity;

namespace Authentication.Server.Data.CustomIdentity
{
    public class CustomIdentityResult : IdentityResult
    {
        public CustomIdentityResult(bool succeeded) : base()
        {
            this.Succeeded = succeeded;
        }
    }
}
