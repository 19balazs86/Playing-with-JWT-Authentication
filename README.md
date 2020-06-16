# Playing-with-JWT

This small application is an example to **set-up the built-in JWT authentication** in .NET Core.

[Separate branch](https://github.com/19balazs86/Playing-with-JWT-Authentication/tree/netcoreapp2.2) with the .NET Core 2.2 version. Difference between AddMvc and AddMvcCore.

#### In the example

- Save and retrieve the Claims from the Token.
- Create SigningCredentials with symmetric and asymmetric security key.
- Validate token.
- Configure to retrieve the token from the cookie too.

#### Basics
- [JWT.io](https://jwt.io)
- [JSON Web Token (JWT) explained.](https://flaviocopes.com/jwt)
- [What is a JSON Web Token?](https://medium.com/myplanet-musings/what-is-a-json-web-token-2193f383e963)
- GitHub: [Jwt.Net](https://github.com/jwt-dotnet/jwt) - Supports generating and decoding JSON Web Tokens.

#### Resources
- [Signing JWT with RSA](https://vmsdurano.com/-net-core-3-1-signing-jwt-with-rsa/) *(ProudMonkey)*
- [Protect your API with API Keys](https://josefottosson.se/asp-net-core-protect-your-api-with-api-keys/) *(Josef)*
- [Certificate Authentication](https://damienbod.com/2019/06/13/certificate-authentication-in-asp-net-core-3-0/) *(Damien Bod)*
- [Creating a custom authentication scheme](https://joonasw.net/view/creating-auth-scheme-in-aspnet-core-2/) (Joonas w)
- [aspnet-contrib / AspNet.Security.OAuth.Providers](https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers) *(GitHub)*
- [Presentation](https://www.youtube.com/watch?v=dDroEVdAqKM) about Authentication and Authorization. [Source code](https://github.com/blowdart/AuthNAuthZPresentationDemos) for the demo. *(Barry Dorrans)*

##### Password hashing
- GitHub: [BcryptNet/bcrypt.net](https://github.com/BcryptNet/bcrypt.net)
- [How to store a password](https://www.meziantou.net/how-to-store-a-password-in-a-web-application.htm).
- [Cryptography in .NET](https://www.meziantou.net/cryptography-in-dotnet.htm).
