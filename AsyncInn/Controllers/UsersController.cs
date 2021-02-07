using AsyncInn.Models.APIs;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AsyncInn.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private IUserService userService;

    public UsersController(IUserService service)
    {
      userService = service;
    }
    /// <summary>
    /// Registers a New User
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    [HttpPost("Register")]
    public async Task<ActionResult<UserDto>> Register(RegisterUser data)
    {
      var user = await userService.Register(data, this.ModelState);
      //RemoveLAter to add roles to people
      
      //
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
    // Whoa! New annotation that will be able to Read the bearer token
    // and return a user based on the claim/principal within...
    [Authorize(Policy="a")]
    [HttpGet("me")]
    public async Task<ActionResult<UserDto>> Me()
    {
      // Following the [Authorize] phase, this.User will be ... you.
      // Put a breakpoint here and inspect to see what's passed to our getUser method
      return await userService.GetUser(this.User);
    }

  }
}
