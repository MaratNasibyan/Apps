using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Server.Data.CustomIdentity
{
    public class CustomRoleManager : RoleManager<Role>
    {
        public CustomRoleManager(IRoleStore<Role> store, IEnumerable<IRoleValidator<Role>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<Role>> logger, IHttpContextAccessor contextAccessor)
           : base(store, roleValidators, keyNormalizer, errors, logger)

        {

        }

        public override async Task<IdentityResult> CreateAsync(Role role)
        {
            try
            {
                return await base.CreateAsync(role);

                //if (confirmEmail)
                //{
                //    var userStore = (CustomUserStore)Store;
                //    await userStore.SetEmailConfirmedAsync(user, true);
                //}
            }
            catch (Exception ex)
            {
                IdentityError error = new IdentityError() { Code = ex.HResult.ToString(), Description = ex.Message };
                return IdentityResult.Failed(error);
            }

        }
    }

    public class Role
    {
        public long ID { get; set; }
    }
}

