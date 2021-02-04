using AsyncInn.Models.APIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
  public interface IUserService
  {
    public Task<ApplicationUser> Register(RegisterUser data);
  }
}
