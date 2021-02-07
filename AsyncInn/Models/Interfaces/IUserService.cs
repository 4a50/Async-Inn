using AsyncInn.Models.APIs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
  public interface IUserService
  {
    public Task<UserDto> Authenticate(string username, string password);
    public Task<UserDto> Register(RegisterUser data, ModelStateDictionary modelState);
    public Task<UserDto> GetUser(ClaimsPrincipal principal);

  }

}
