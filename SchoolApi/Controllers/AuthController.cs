using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolApi.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        
        private readonly List<(string Username, string Password, string Role)> _users =
            new List<(string, string, string)>
            {
                ("admin","password123","Admin"),
                ("user","password123","User")
            };

        public AuthController(IOptions<JwtSettings> jwtOptions)
        {
            _jwtSettings = jwtOptions.Value;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest req)
        {
            var user = _users.SingleOrDefault(u => u.Username == req.Username && u.Password == req.Password);
            if (user == default) return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                            SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return Ok(new { token = jwt });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
