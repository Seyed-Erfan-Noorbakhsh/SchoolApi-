using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SchoolApi.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _key;
        private readonly string _issuer;

        public JwtMiddleware(RequestDelegate next, IConfiguration iConfig)
        {
            _next = next;
            _key = iConfig["Jwt:Key"];
            _issuer = iConfig["Jwt:Issuer"];
        }

        public async Task InvokeAsync(HttpContext iContext)
        {
            var token = iContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                await _next(iContext);
                return;
            }

            var handler = new JwtSecurityTokenHandler();
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)),
                ValidIssuer = _issuer,
                ValidateLifetime = true
            };

            try
            {
                handler.ValidateToken(token, parameters, out _);
            }
            catch
            {
                iContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await iContext.Response.WriteAsync("{\"error\":\"Invalid or expired token\"}");
                return;
            }

            await _next(iContext);
        }
    }
}
