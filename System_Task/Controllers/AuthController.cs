using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System_Task.Commands.Auth;
using System_Task.Responses.Auth;

namespace System_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // for DI
        private readonly string TokenSecret;
        private readonly string TokenIssuer;
        private readonly string TokenAudience;

        public AuthController(IConfiguration config)
        {
            TokenSecret = config.GetValue<string>("JWT:Secret");
            TokenIssuer = config.GetValue<string>("JWT:ValidIssuer");
            TokenAudience = config.GetValue<string>("JWT:ValidAudience");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginCommand user)
        {
            var claims = new List<Claim>();
            if (user is null)
                return BadRequest("Invalid user request!!!");
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
                return BadRequest("User Name and Password is required");
            else
                claims.Add(new Claim("username", user.UserName));

            if (user.UserName == "admin" && user.Password == "admin")
                claims.Add(new Claim(ClaimTypes.Role, "Admin", null, TokenIssuer));

            if (user.UserName == "client" && user.Password == "123")
                claims.Add(new Claim(ClaimTypes.Role, "Client", null, TokenIssuer, ClaimsIdentity.DefaultRoleClaimType));

            if (claims?.Count > 1)
                return Ok(new LoginResponse
                {
                    Token = GetToken(claims, TokenSecret, TokenIssuer, TokenAudience, DateTime.Now.AddDays(1))
                });
            return BadRequest("Invalid User name or password!");
        }

        private static string GetToken(List<Claim> claims, string secret, string issuer, string audience, DateTime expireTime)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(issuer: issuer, audience: audience, claims: claims, expires: expireTime, signingCredentials: signinCredentials);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;

        }
    }
}
