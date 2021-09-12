using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Webshop.DataProviders;

namespace Webshop.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController: ControllerBase
    {
        private readonly Settings _settings;
        private readonly UserDataProvider _userDataProvider;
        public LoginController(Settings settings, UserDataProvider userDataProvider)
        {
            _settings = settings;
            _userDataProvider = userDataProvider;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = await _userDataProvider.VerifyUser(login.Username, login.Password);
            if (user == null) return response;
            var tokenString = GenerateJSONWebToken(login);
            response = Ok(new { token = tokenString });
            return response;
        }
        private string GenerateJSONWebToken(LoginModel login)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.JwtConfig.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_settings.JwtConfig.Issuer,
                _settings.JwtConfig.Issuer,
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}