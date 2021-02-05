using System.Collections.Generic;

namespace AsyncInn.Models.APIs
{
  public class UserDto
  {
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }
    public IList<string> Roles { get; set; }
  }
}
