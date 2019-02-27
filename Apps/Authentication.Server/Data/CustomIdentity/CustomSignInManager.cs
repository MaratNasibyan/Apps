using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Authentication.Server.Data.CustomIdentity
{
    public class CustomSignInManager : SignInManager<CustomIdentityUser>
    {
        public CustomSignInManager(CustomIdentityUserManager userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<CustomIdentityUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<CustomIdentityUser>> logger, IAuthenticationSchemeProvider provider)
      : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, provider)
        {
           
        }

        public override async Task<SignInResult> PasswordSignInAsync(CustomIdentityUser user, string password, bool isPersistent, bool lockoutOnFailure)
        {
            SignInResult result = await base.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
            if (result.Succeeded)
            {
               
            }

            return result;
        }
    }
}
