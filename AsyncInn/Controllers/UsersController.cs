using AsyncInn.Models;
using AsyncInn.Models.APIs;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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


  }
}
