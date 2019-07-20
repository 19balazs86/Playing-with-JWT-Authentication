# Playing-with-JWT

This small application is an example to **set-up the built-in JWT authentication** in .NET Core.
- Save and retrieve the Claims from the Token.
- Create SigningCredentials with symmetric and asymmetric security key.
- Validate token.
- Configure to retrieve the token from the cookie too.

#### Difference between AddMvc and AddMvcCore
- In the Startup file ConfigureServices: the default AddMvc extension method is replaced by **AddMvcCore**. You can save some resources by skipping include the razor functionality (usually, you do not use that in WebAPI).
- Blog: [Difference between AddMvc and AddMvcCore](https://offering.solutions/blog/articles/2017/02/07/difference-between-addmvc-addmvcore).
- Blog: [Replace AddMvc with AddMvcCore](https://blog.codingmilitia.com/2019/01/26/aspnet-012-from-zero-to-overkill-move-to-a-web-api).
- Blog: [Reducing initial request latency by pre-building services in a startup task](https://andrewlock.net/reducing-latency-by-pre-building-singletons-in-asp-net-core).

#### Basics
- [JWT.io](https://jwt.io)
- [JSON Web Token (JWT) explained.](https://flaviocopes.com/jwt)
- [What is a JSON Web Token?](https://medium.com/myplanet-musings/what-is-a-json-web-token-2193f383e963)
- [GitHub: Jwt.Net](https://github.com/jwt-dotnet/jwt) - Supports generating and decoding JSON Web Tokens.

#### Resources
- Blog: [Protect your API with API Keys](https://josefottosson.se/asp-net-core-protect-your-api-with-api-keys/) - custom Authentication and Authorization.
- Blog: [Certificate Authentication](https://damienbod.com/2019/06/13/certificate-authentication-in-asp-net-core-3-0/).
- Blog: [Creating a custom authentication scheme](https://joonasw.net/view/creating-auth-scheme-in-aspnet-core-2/).
- GitHub: [aspnet-contrib / AspNet.Security.OAuth.Providers](https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers)
- Barry Dorrans: [Presentation](https://www.youtube.com/watch?v=dDroEVdAqKM) about Authentication and Authorization. [Source code](https://github.com/blowdart/AuthNAuthZPresentationDemos) for the demo.

##### Password hashing
- GitHub: [BcryptNet/bcrypt.net](https://github.com/BcryptNet/bcrypt.net)
- [How to store a password](https://www.meziantou.net/how-to-store-a-password-in-a-web-application.htm).
- [Cryptography in .NET](https://www.meziantou.net/cryptography-in-dotnet.htm).
