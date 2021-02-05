using AsyncInn.Models.APIs;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AsyncInn.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  //TODO: PolicyIssues
  public class UsersController : ControllerBase
  {
    private IUserService userService;

    public UsersController(IUserService service)
    {
      userService = service;
    }
    /// <summary>
    /// Registers a New User with any role.
    /// REQUIRES: UserAdd Policy
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    [Authorize(Policy = "useradd")]
    [HttpPost("RegisterAll")]
    public async Task<ActionResult<UserDto>> RegisterAll(RegisterUser data)
    {
      var user = await userService.Register(data, this.ModelState);
      if (ModelState.IsValid)
      {
        return user;
      }
      return BadRequest(new ValidationProblemDetails(ModelState));
    }
    
    [Authorize(Policy = "agentadd")]
    [HttpPost("RegisterAgent")]
    public async Task<ActionResult<UserDto>> RegisterAgent(RegisterUser data)
    {
      
      if (data.Roles.Contains("propertymanager") || data.Roles.Contains("districtmanager")){
        return BadRequest("Roles are not authorized at this level.");

      }
        var user = await userService.Register(data, this.ModelState);
      
      if (ModelState.IsValid)
      {
        return user;
      }
      return BadRequest(new ValidationProblemDetails(ModelState));
    }
    /// <summary>
    /// Authenticates a User Login
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    [HttpPost("Login")]
    public async Task<ActionResult<UserDto>> Login(LoginData login)
    {
      var user = await userService.Authenticate(login.UserName, login.Password);
      if (user != null)
      {
        return user;
      }
      return Unauthorized();
    }
   // [Authorize(Roles ="districtmanager")]
    [HttpGet("Me")]
    public async Task<ActionResult<UserDto>> Me()
    {
      return await userService.GetUser(this.User);
    }



  }
}
