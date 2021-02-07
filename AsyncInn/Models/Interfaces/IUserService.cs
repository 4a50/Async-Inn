using AsyncInn.Models.APIs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
  public interface IUserService
  {
    public Task<UserDto> Register(RegisterUser data, ModelStateDictionary modelState);
    public Task<UserDto> Authenticate(string username, string password);

  }

}
