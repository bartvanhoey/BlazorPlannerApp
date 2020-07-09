using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PlannerApp.Client.Models;

namespace PlannerApp.Client
{
  public class LocalAuthenticationStateProvider : AuthenticationStateProvider
  {

    private readonly ILocalStorageService _localStorageService;

    public LocalAuthenticationStateProvider(ILocalStorageService localStorageService)
    {
      _localStorageService = localStorageService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
      if (await _localStorageService.ContainKeyAsync("User"))
      {
        var userInfo = await _localStorageService.GetItemAsync<LocalUserInfo>("User");
        var claims = new[] {
            new Claim("Email", userInfo.Email),
            new Claim("LastName", userInfo.LastName),
            new Claim("FirstName", userInfo.FirstName),
            new Claim("AccessToken", userInfo.AccessToken),
            new Claim(ClaimTypes.NameIdentifier, userInfo.Id)
        };
        var identity = new ClaimsIdentity(claims, "BearerToken");
        var user = new ClaimsPrincipal(identity);
        return new AuthenticationState(user);
      }
      else
      {
          return new AuthenticationState(new ClaimsPrincipal());
      }
    }
  }
}