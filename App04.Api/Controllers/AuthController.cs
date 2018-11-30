using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using App04.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace App04.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration config;

        public AuthController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public ActionResult<AuthResult> LogIn(AuthLogIn login)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, login.UserName),
                new Claim("LuckyNumber", "9922")
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return Ok(new AuthResult
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}