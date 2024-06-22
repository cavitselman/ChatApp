using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CApp.Authentication
{
    internal static class IdentityComponents
    {
        public static IEndpointConventionBuilder MapAdditionalIdentityEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var accountGroup = endpoints.MapGroup("/Account");
            accountGroup.MapPost("/Logout", async (ClaimsPrincipal user, SignInManager<AppUser> signInManager) =>
            {
                await signInManager.SignOutAsync();
                return TypedResults.LocalRedirect("/");
            });
            return accountGroup;
        }
    }
}
