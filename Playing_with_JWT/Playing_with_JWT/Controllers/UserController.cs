using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Playing_with_JWT.Model;

namespace Playing_with_JWT.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    [HttpPost("login")]
    public IActionResult Login(LoginModel loginModel)
    {
      if (loginModel.Name == "test" && loginModel.Password == "pass")
      {
        UserModel user = new UserModel(1, loginModel.Name, new []{ "User" });

        return Ok(new { Token = TokenAuthenticationFactory.CreateToken(user.ToClaims()) });
      }

      return Unauthorized();
    }

    [Authorize]
    [HttpGet]
    public UserModel Get()
    {
      UserModel user = new UserModel(User.Claims);

      return user;
    }
  }
}