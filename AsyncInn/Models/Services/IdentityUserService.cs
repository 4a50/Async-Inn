using AsyncInn.Models.APIs;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
  public class IdentityUserService : IUserService
  {
    public Task<ApplicationUser> Register(RegisterUser data)
    {
      throw new NotImplementedException();
    }
  }
}
