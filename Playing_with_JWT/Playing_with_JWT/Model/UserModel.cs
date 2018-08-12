using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Playing_with_JWT.Model
{
  public class UserModel
  {
    public string Name { get; }
    public IEnumerable<string> Roles { get; }

    public UserModel(string name, IEnumerable<string> roles)
    {
      Name  = name;
      Roles = roles;
    }

    public UserModel(IEnumerable<Claim> claims)
    {
      List<string> roles = new List<string>();

      foreach (Claim claim in claims)
      {
        switch (claim.Type)
        {
          case ClaimTypes.Name: Name = claim.Value;
            break;
          case ClaimTypes.Role: roles.Add(claim.Value);
            break;
        }
      }

      Roles = roles;
    }

    public IEnumerable<Claim> ToClaims()
    {
      List<Claim> claims = new List<Claim> {
        new Claim(ClaimTypes.Name, Name)
      };

      claims.AddRange(Roles.Select(r => new Claim(ClaimTypes.Role, r)));

      return claims;
    }
  }
}
