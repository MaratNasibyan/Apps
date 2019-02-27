using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Authentication.Server.Data.CustomIdentity
{
    public class CustomIdentityUserManager : UserManager<CustomIdentityUser>
    {
        public CustomIdentityUserManager(IUserStore<CustomIdentityUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<CustomIdentityUser> passwordHasher, IEnumerable<IUserValidator<CustomIdentityUser>> userValidators, IEnumerable<IPasswordValidator<CustomIdentityUser>> passwordValidators, ILookupNormalizer keyNormalizer,
                IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<CustomIdentityUser>> logger)
                 : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
           
        }

        public override async Task<IdentityResult> CreateAsync(CustomIdentityUser user/*, string password, bool confirmEmail*/)
        {
            try
            {
                return await base.CreateAsync(user);              
            }
            catch (Exception ex)
            {
                IdentityError error = new IdentityError() { Code = ex.HResult.ToString(), Description = ex.Message };
                return IdentityResult.Failed(error);
            }

        }

        public override async Task<IdentityResult> CreateAsync(CustomIdentityUser user, string password)
        {
            try
            {
                return await base.CreateAsync(user, password);

            }
            catch (Exception ex)
            {
                IdentityError error = new IdentityError() { Code = ex.HResult.ToString(), Description = ex.Message };
                return IdentityResult.Failed(error);
            }

        }

        public override async Task<IdentityResult> UpdateAsync(CustomIdentityUser user)
        {
            Task<IdentityResult> UpdateTask = base.UpdateAsync(user);

            try
            {
                IdentityResult identityResult = await UpdateTask;
            }
            catch (Exception ex)
            {
                IdentityError error = new IdentityError() { Code = ex.HResult.ToString(), Description = ex.Message };
                return IdentityResult.Failed(error);
            }
            return UpdateTask.Result;

        }

        //public override async Task<IdentityResult> ResetPasswordAsync(CustomIdentityUser user, string token, string newPassword)
        //{
        //    IAccountService accountService = (IAccountService)this._serviceProvider.GetService(typeof(IAccountService));
        //    IEnumerable<PasswordHistory> oldhashes = await accountService.GetPreviousPasswordHashes(user.DBUser.ID);

        //    foreach (var oldhash in oldhashes)
        //    {
        //        var result = this.PasswordHasher.VerifyHashedPassword(user, oldhash.PasswordHash, newPassword);
        //        if (result == PasswordVerificationResult.Success)
        //            return IdentityResult.Failed(new IdentityError() { Description = "Password previously used" });
        //    }

        //    return await base.ResetPasswordAsync(user, token, newPassword);
        //}
        //public override async Task<IdentityResult> ChangePasswordAsync(CustomIdentityUser user, string currentPassword, string newPassword)
        //{
        //    //verify current password
        //    var verify = await base.VerifyPasswordAsync(Store as IUserPasswordStore<CustomIdentityUser>, user, currentPassword);
        //    if (verify == PasswordVerificationResult.Failed)
        //        return IdentityResult.Failed(new IdentityError() { Code = "PasswordMismatch", Description = "Current password is not correct" });

        //    IAccountService accountService = (IAccountService)this._serviceProvider.GetService(typeof(IAccountService));
        //    IEnumerable<PasswordHistory> oldhashes = await accountService.GetPreviousPasswordHashes(user.DBUser.ID);

        //    foreach (var oldhash in oldhashes)
        //    {
        //        var result = this.PasswordHasher.VerifyHashedPassword(user, oldhash.PasswordHash, newPassword);
        //        if (result == PasswordVerificationResult.Success)
        //            return IdentityResult.Failed(new IdentityError() { Code = "UsedPassword", Description = "Password previously used" });
        //    }

        //    return await base.ChangePasswordAsync(user, currentPassword, newPassword);
        //}

        //public bool VerifyHashedPassword(CustomIdentityUser user, string password)
        //{
        //    PasswordVerificationResult result = PasswordVerificationResult.Failed;
        //    if (user.DBUser.PasswordHash == null)
        //    {
        //        return result == PasswordVerificationResult.Success;
        //    }
        //    else
        //    {
        //        result = this.PasswordHasher.VerifyHashedPassword(user, user.DBUser.PasswordHash, password);
        //    }
        //    return result == PasswordVerificationResult.Success;
        //}

    }
}
