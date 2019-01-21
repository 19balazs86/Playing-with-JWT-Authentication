using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Playing_with_JWT
{
  public static class TokenAuthenticationFactory
  {
    private static readonly string _issuer         = "http://localhost:5000";
    private static readonly string _audience       = "http://localhost:5000";
    private static readonly string _base64CertFile = "MIIKEQIBAzCCCdcGCSqGSIb3DQEHAaCCCcgEggnEMIIJwDCCBHcGCSqGSIb3DQEHBqCCBGgwggRkAgEAMIIEXQYJKoZIhvcNAQcBMBwGCiqGSIb3DQEMAQYwDgQI8fcjcPNha5MCAggAgIIEMLa4SuU0jhPFSOuO/FRxbEjOAy9JETVvXiwHH0zoz7UncxGTmHb+/DN2GZ7XzMhb6hszv8zJv3bT1SN17wvyPZn96Om65Bqew7SOvP9uEIX60jR5M5UiX8UwQ/ToLKCMcKxaHvztwmO2TSWI2T+BhCS/B1XnImnnHDh5salAjvGPcHG1k/LtGdHGVqcVMNOQZsxkv+gOKxUA1rtHr5Qr5gG4954r873bfB+67+ScMZXib8Pud4plXunTWi7q0PkZvG/Cr4Q/fhoGy+rQgNa4jxW0jFEdyleR+VS4PkBT96Uu+lXgT9lSy4u4/xr/fQtZse4EfdIQPuiknySyjLimGutrl9OATNMTBXXXLj08CgpgVP/d9XilrkHD0/WEvPTiCcrGgHwJy285j3Xpz6pDTJDiBjx+pMIYxeZfN4R4TKaGy0svC4tqtBPbtgj9NBImysS5hDw8ZH0R7B8ME5O96UalVGl1S07PRR53kJ6xPJAr5NFPR2TOrDnjEJUUht9AjaVGXEfZjf0rq5A3U5sdFmvuCAOr1FKKexqn1qLjiZxOCgyMuL1AISBcGC+DOZwsMyGwbEdTra7rJIT2eK8eB/NGJNtEwt0hMzAiC8/dus/9frpkVGeOzZlPkrDPzWdTFw+OO8u+FMdwVFVjiLaAOs1BnQ81+nKQyhORouuJEoMMZ9dgtupIZ1A302CPKE21Qsf5PRLmOHJiitvvHZ655ltj2lhONfUQ39XjvQ02QjKtAPW+ubpYK1EDgNF+Wip+/AXRjRqxdV0Hmx3JCSFEifX7MIumojKr4FBk2ygWt+AV4VjkxS9bqjkM5dXGpd3y2Xf/geYrLOgLkZB4VmyKfY3ZGlthIPtNjujMncryYXxdlP62eHo45QWEEG+U4qkMVDWdktkuarec9A8SRD5EbiTipdDmoMxRZTIQZlDW8893i1DpG7lbutFy0ZME0xBJsmkge5Iyz8FapuY9/1AtAZvQatBLoQHtAHhAJ3S2gBtPKFI0+PnGc62TL8xxTuoTXbt4e+nss58SSp7WMfnYs4VTH8VsosC7uJYdyqA8eViUN3tTCGN0FC2INEeneTIhmnt35pko/twlk6uGxY1+m5TPdOkeEPoApWms/8FlXtXU36+aqDJ/JwnbPqEcHE/AsHA1RyK1Ky7CbPVO/pCOJgt/JAiAOKRuJEzO3OMNn4/pix8RGMuF13PqJ+Ms22i6pDKcv+POsm2mjXxCyzQKMwfJOOywnxPWWIreY2cIe2q6imepfcxZauE8Kxti/ufZqJ6QUOeGrsMv7cQkUgyPCCgfDKulX/RWIq6jtLfX26KTtlFHPirLGPCRhJDn8FKvFCLTANHz5da60Z/9Z2RHgFltrLWPCvE5/j7NxfHxo1a0d3pEt0pkdSJ311FVuh5XXFifCQ4yEsY/8sUQKdfGmWEwggVBBgkqhkiG9w0BBwGgggUyBIIFLjCCBSowggUmBgsqhkiG9w0BDAoBAqCCBO4wggTqMBwGCiqGSIb3DQEMAQMwDgQIePbfSekWoJYCAggABIIEyJyM51wVkkchL5GpPBGetR6LD11SeBy04AQMzcFF7H4ZlRmy14osJWrfLWyAFI5wEMlTE7X4HH/MWOR7bvbmopo2ehDa8uKs/RL4/P1dgwwHZXDTjPo9py27zfLYfAembIZwBxH/Qm9Zu69fjcUNLTy3AQTd/ETzNmTGbDots/wcgPufmomfkxffiFWQLPHCIYzyH3B/ypW10XJ4UBJD12A93AG+kUMEQvVx9NTJhx3EoiFN3mq2KxjLm4NgWoGk+o0PO8POu4MNA5865O40eAoeBm8a7ObDb1IYSBAyxg2uUG7SpDKlmurONVLqPD7VsfmimR9X9vCmw9+lw9S02J9VgnZVjJp0J7sUTkT+d8/uf9+2RnPdQc5Oc6MNGEDbIBgQmoYads7ue+5E6CVRHBtKgLtuTbsbY7BUF/3GnC9jT7Sv9FlIVGK/uAXztPkXabMRkiWq3fg/UaI1I/xHY7trmqjcOiPgxlNAanrtgpVlyp7/9TPBrtPlSY2cNbDkUWM36vXIS54tcS51YNdKyrcli/TtQAQn5rwkjChSzrbI9GbIhCNRjSkbeBf/O3AKxMbFFKMxDspBa1C2S0EDi/s8rrerGklHiS1aOYULokQplN6y3ud4HE/orctv9x3ayFm8qYh5E7ITfPNda+LJged7NsQ/lOFuP5yjk3bUPFe9Px7b6GgDBAbmakIOniwSsCJ/8ahBvVt/zeSKiOpsPyiTSfV17wGz7lqDK/kMhQvkPfhq7kjPhsrsxHQ3Xz1jT1Uj1v2U2a41990ZTGory31mTvF41o7xmk/vTrC4Sh/+HUDYjNSerjNM0b60a7y8juS4Skh3sWYr5GHnRjz1kxlvXn7Qj2YAPUN6LURQwRw8lxBaXKZH7tbVMmSxq6zDUqGQeIljmbmOZgRO1H3QO3EPTkABBHdZheXxvb+PGgdEU9X6JU6APIX5TyCZEpt3n1YEpixYd3uYWyaNUjrPq1cKQG07Ty9c395IWDibcWUZlCbjNcVaQux4YuuMOzltSaZOhOL2pV2Zm5NdPsyTgiS1Ig1LqPE6PhDJKE9LhdFvhGeiBxPDyJd/eb4sOT0vjF+RAAIdWfFqbho7QuYp5nGUfTUDMoTKijazwSdG0gQ5vlGu6oBY4pxoUnRMUL177BoUV8YYakeZLzzQvpZxQpRToDP/acjqM6ebUyyyLZ307Db3/3XLiNt/YEpu2gbelYmx25coY2ugORj6FCNZSkOas0pIkn2Z/H2140Op8H1TVDVerKddut13HUh3BvGtMlNPeHJg8I3+ivJvegpNJEZJezlSFKcFvR0P5N69QcMr5rS0PiznP9bjJoM2GXZNtWLpSLMO7mRNOAB61Qb+V+uBgpjMv+qU0Zq69TU3qpK35s+N7rcvAmybJ9Xk5rKaLAnnCYSLmd/pppN9BiOw3GycQ8ioSFo/yVXReapPVymugQ5Cov7K0W4c2OhL0/Qxf30GnfNM/Bf/HGHZEKHUtrXF1lf3lhxsn0nvvQCr39G6NriJGNOdn4VGtcX01MsjNb9mB7ndBB6rpFVwOY7qUK53/262Bl+H3QWNlA7OBaJk79dAQcr/cK77u25i2lr+PSj4vM5p7a30Tl9XvQ1zs+S6o+VvF95lajElMCMGCSqGSIb3DQEJFTEWBBTragZ5NnHBLVZ4vLWjuf4sKRhTDTAxMCEwCQYFKw4DAhoFAAQUvwUmJcgWugotvWhVYvJvNc74l1cECPrZIoeVXIpnAgIIAA==";
    private static readonly X509Certificate2 _cert = new X509Certificate2(Convert.FromBase64String(_base64CertFile), "test");

    //private static SecurityKey _securityKeySymm = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));

    private static readonly SecurityKey _securityKeyX509 = new X509SecurityKey(_cert);

    // You can use the SymmetricSecurityKey with SecurityAlgorithms.HmacSha256
    private static readonly SigningCredentials _signingCredential =
      new SigningCredentials(_securityKeyX509, SecurityAlgorithms.RsaSha256);

    private static readonly TokenValidationParameters _tokenValidationParameters = new TokenValidationParameters
    {
      ValidateIssuer           = true,
      ValidateAudience         = true,
      ValidateLifetime         = true,
      ValidateIssuerSigningKey = true,

      ValidIssuer      = _issuer,
      ValidAudience    = _audience,
      IssuerSigningKey = _securityKeyX509
    };

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
    {
      services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options => options.TokenValidationParameters = _tokenValidationParameters);

      return services;
    }

    public static string CreateToken(IEnumerable<Claim> claims)
    {
      SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject            = new ClaimsIdentity(claims),
        Issuer             = _issuer,
        Audience           = _audience,
        Expires            = DateTime.Now.AddDays(1),
        SigningCredentials = _signingCredential
      };

      SecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

      SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

      return tokenHandler.WriteToken(token);
    }

    public static bool TryValidateToken(string token, out ClaimsPrincipal claimsPrincipal)
    {
      SecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

      try
      {
        claimsPrincipal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var securityToken);

        return true;
      }
      catch (Exception) // The exception can be: ArgumentException, SecurityTokenValidationException
      {
        claimsPrincipal = null;

        return false;
      }
    }
  }
}
