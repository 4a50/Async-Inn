using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models.APIs
{
  public class RegisterUser
  {
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<string> Roles { get; set; }

  }
}
