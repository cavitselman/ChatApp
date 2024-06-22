using CAppModels.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace CApp.Client.Authentication
{
    public class PersistingAuthentication : AuthenticationStateProvider
    {
        private static readonly Task<AuthenticationState> defaultAuthenticatedTask = Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));

        private readonly Task<AuthenticationState?> authenticationStateTask = defaultAuthenticatedTask;

        public PersistingAuthentication(PersistentComponentState state)
        {
            if (!state.TryTakeFromJson<UserInfo>(nameof(UserInfo), out var userInfo) || userInfo is null)
                return;

            Claim[] claims = [
                new Claim(ClaimTypes.NameIdentifier, userInfo.Id!),
                new Claim(ClaimTypes.Email, userInfo.Email!),
                new Claim(ClaimTypes.Name, userInfo.Fullname!)
                ];

            authenticationStateTask = Task.FromResult(
                new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, nameof(PersistingAuthentication)))))!;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        => authenticationStateTask!;
    }
}
