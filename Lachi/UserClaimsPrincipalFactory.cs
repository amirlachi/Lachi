using Lachi.Data.Entities.UserStuff;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

using System.Security.Claims;

namespace Lachi
{
    public class UserClaimsPrincipalFactory:UserClaimsPrincipalFactory<User, Role>
    {
        public UserClaimsPrincipalFactory(
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, roleManager, optionsAccessor) { }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            string fullNameVal = user.UserName!;
            if (!string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName))
                fullNameVal = user.FirstName + " " + user.LastName;
            identity.AddClaim(new Claim("FullName", fullNameVal));

            return identity;
        }
    }
}
