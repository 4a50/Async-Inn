using AsyncInn.Models.APIs;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
  public class IdentityUserService : IUserService
  {
    private UserManager<ApplicationUser> userManager;
    private JwtTokenService tokenService;

    public IdentityUserService(UserManager<ApplicationUser> manager, JwtTokenService jwtTokenService)
    {
      userManager = manager;
      tokenService = jwtTokenService;
    }
    /// <summary>
    /// Authenticates User Name and Password with values stored in the database
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<UserDto> Authenticate(string username, string password)
    {
      var user = await userManager.FindByNameAsync(username);
      if (await userManager.CheckPasswordAsync(user, password))
      {
        return new UserDto
        {
          Id = user.Id,
          UserName = user.UserName,
          Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(15))
        };
      }
      return null;
    }
    /// <summary>
    /// Registers a New User and returns a new token
    /// </summary>
    /// <param name="data"></param>
    /// <param name="modelState"></param>
    /// <returns></returns>
    public async Task<UserDto> Register(RegisterUser data, ModelStateDictionary modelState)
    {
      //throw new NotImplementedException();

      var user = new ApplicationUser
      {
        UserName = data.UserName,
        Email = data.Email,
        PhoneNumber = data.PhoneNumber
      };

      var result = await userManager.CreateAsync(user, data.Password);

      if (result.Succeeded)
      {
        // Because we have a "Good" user, let's add them to their proper role
        await userManager.AddToRolesAsync(user, data.Roles);
        return new UserDto
        {
          Id = user.Id,
          UserName = user.UserName,
          Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(15)),
          Roles = await userManager.GetRolesAsync(user)
        };
      }

      // Put errors into modelState
      // Ternary:   var foo = conditionIsTrue ? goodthing : bad;
      foreach (var error in result.Errors)
      {
        var errorKey =
          error.Code.Contains("Password") ? nameof(data.Password) :
          error.Code.Contains("Email") ? nameof(data.Email) :
          error.Code.Contains("UserName") ? nameof(data.UserName) :
          "";

        modelState.AddModelError(errorKey, error.Description);
      }

      return null;
    }
    public async Task<UserDto> GetUser(ClaimsPrincipal principal)
    {
      var user = await userManager.GetUserAsync(principal);
      return new UserDto
      {
        Id = user.Id,
        UserName = user.UserName
      };
    }
  }
}
