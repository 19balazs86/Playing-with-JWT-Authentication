using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Playing_with_JWT.Model;

namespace Playing_with_JWT.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginModel)
    {
      if (loginModel.Name == "test" && loginModel.Password == "pass")
      {
        UserIdentity user = new UserIdentity(1, loginModel.Name, new []{ loginModel.Role });

        return Ok(new { Token = TokenAuthenticationFactory.CreateToken(user.ToClaims()) });
      }

      return Unauthorized();
    }

    [HttpGet]
    public UserIdentity Get() => new UserIdentity(User.Claims);

    //[Authorize(Roles = "Admin")] // This can be used too.
    [Authorize(Policy = "Admin")]
    [HttpGet("admin")]
    public UserIdentity GetAdmin() => new UserIdentity(User.Claims);

    [AllowAnonymous]
    [HttpPost("validate-token")]
    public ActionResult<UserIdentity> ValidateToken(ValidateTokenRequest validateTokenRequest)
    {
      if (TokenAuthenticationFactory.TryValidateToken(validateTokenRequest.Token, out var claimsPrincipal))
      {
        UserIdentity user = new UserIdentity(claimsPrincipal.Claims);

        return Ok(user);
      }

      return BadRequest();
    }
  }
}