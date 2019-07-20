using System.ComponentModel.DataAnnotations;

namespace Playing_with_JWT.Model
{
  public class LoginRequest
  {
    [Required]
    public string Name { get; set; }

    [Required]
    public string Password { get; set; }
  }
}
