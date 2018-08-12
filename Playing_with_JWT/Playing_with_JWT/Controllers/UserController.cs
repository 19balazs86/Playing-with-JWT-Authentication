using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Playing_with_JWT.Model;

namespace Playing_with_JWT.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    [HttpPost, Route("login")]
    public IActionResult Login([FromBody]LoginModel loginModel)
    {
      if (loginModel.Name == "test" && loginModel.Password == "pass")
      {
        UserModel user = new UserModel(loginModel.Name, new []{ "User" });

        return Ok(new { Token = TokenAuthenticationFactory.GenerateToken(user.ToClaims()) });
      }

      return Unauthorized();
    }

    [Authorize]
    [HttpGet]
    public ActionResult<UserModel> Get()
    {
      UserModel user = new UserModel(User.Claims);

      return Ok(user);
    }
  }
}