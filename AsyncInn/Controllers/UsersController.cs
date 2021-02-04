using AsyncInn.Models;
using AsyncInn.Models.APIs;
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
    [HttpPost("register")]
    public async Task<ActionResult<ApplicationUser>> Register(RegisterUser data)
    {
      return new ApplicationUser();
    }

  }
}
