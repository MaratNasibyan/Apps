using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using RESTful.Catalog.API.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.Server.Data.CustomIdentity
{
    public class CustomUserStore : IUserStore<CustomIdentityUser>
       , IUserPasswordStore<CustomIdentityUser>
       , IUserSecurityStampStore<CustomIdentityUser>
       , IUserLockoutStore<CustomIdentityUser>
       , IUserEmailStore<CustomIdentityUser>
    {
        public CustomUserStore(IOptions<AppSettings> appSettings, IHttpContextAccessor accessor)
        {
            //_accountService = accountService;
            //_userService = userService;
            //_guestUserService = guestUserService;
            //_appSettings = appSettings;
            //_accessor = accessor;
        }
      
        #region IUserStore

        public Task<IdentityResult> CreateAsync(CustomIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(CustomIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<CustomIdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CustomIdentityUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(CustomIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }



        public Task<string> GetUserIdAsync(CustomIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(CustomIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

       

        public Task SetNormalizedUserNameAsync(CustomIdentityUser user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

      

        public Task SetUserNameAsync(CustomIdentityUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(CustomIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserPasswordStore
        public Task<string> GetPasswordHashAsync(CustomIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        public Task SetPasswordHashAsync(CustomIdentityUser user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(CustomIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region IUserSecurityStampStore
        public Task SetSecurityStampAsync(CustomIdentityUser user, string stamp, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSecurityStampAsync(CustomIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region IUserLockoutStore
        public Task<DateTimeOffset?> GetLockoutEndDateAsync(CustomIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(CustomIdentityUser user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(CustomIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        public Task ResetAccessFailedCountAsync(CustomIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(CustomIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(CustomIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(CustomIdentityUser user, bool enabled, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region IUserEmailStore
        public Task SetEmailAsync(CustomIdentityUser user, string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(CustomIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmailConfirmedAsync(CustomIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(CustomIdentityUser user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CustomIdentityUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedEmailAsync(CustomIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedEmailAsync(CustomIdentityUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
