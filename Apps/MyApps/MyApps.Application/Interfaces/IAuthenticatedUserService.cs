using System;
using System.Collections.Generic;
using System.Text;

namespace MyApps.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
    }
}
