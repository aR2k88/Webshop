using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Webshop.Middleware
{
    public class JwtTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly Settings _settings;

        public JwtTokenMiddleware(RequestDelegate next, JwtSecurityTokenHandler jwtSecurityTokenHandler,
            Settings settings)
        {
            _next = next;
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
            _settings = settings;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var authenticationCookieName = "access_token";
                var token = context.Request.Cookies[authenticationCookieName];
                if (token != null)
                {
                    // Validation 1 - Validation JWT token format
                    var tokenInVerification =
                        _jwtSecurityTokenHandler.ValidateToken(token, new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = _settings.JwtConfig.Issuer,
                            ValidAudience = _settings.JwtConfig.Issuer,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.JwtConfig.Secret))
                        }, out var validatedToken);

                    if (validatedToken is JwtSecurityToken jwtSecurityToken)
                    {
                        var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                            StringComparison.InvariantCultureIgnoreCase);
                        
                        if (result && validatedToken.ValidTo > DateTime.UtcNow)
                        {
                            await _next(context);
                        }
                        else
                        {
                            await HandleException(context);
                        }
                    }
                }
                else
                {
                    await HandleException(context);
                }
            }
            catch (Exception ex)
            {
                Error Invalid = new Error()
                {
                    Success = false,
                    Errors = "Token does not match or may expired."
                };
                context.Items["Error"] = Invalid; // userService.GetById(userId);
            }
        }

        private static Task HandleException(HttpContext context)
        {
            HttpStatusCode code = HttpStatusCode.Unauthorized; // 500 if unexpected

            // Specify different custom exceptions here

            string result = JsonConvert.SerializeObject(new Error {Errors = "Not Authorized ", Success = false});

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }

    public class Error
    {
        public bool Success { get; set; }
        public string Errors { get; set; }
    }
}
