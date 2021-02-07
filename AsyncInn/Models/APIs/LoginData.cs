using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models.APIs
{
  public class LoginData
  {
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
  }
}
