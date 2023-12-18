using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Auth
{
    public interface IEntity
    {

    }
    public class Role : IdentityRole<int>, IEntity
    {
    }
    public class RoleClaim : IdentityRoleClaim<int>, IEntity
    {
    }

    public class User : IdentityUser<int>, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RefreshToken { get; set; } = "";

    }
    public class UserClaim : IdentityUserClaim<int>, IEntity
    {
    }
    public class UserLogin : IdentityUserLogin<int>, IEntity
    {
    }
    public class UserRole : IdentityUserRole<int>, IEntity
    {
    }
    public class UserToken : IdentityUserToken<int>, IEntity
    {
    }
}
