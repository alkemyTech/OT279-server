using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OngProject.Middleware
{
    public class PermissionAuthorizationMiddleware
    {

        private readonly RequestDelegate _next;

        public PermissionAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (string.IsNullOrEmpty(token))
                { 
                    throw new Exception("Token invalido");
                }
                
                var securityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                if (!securityToken.Claims.Any(claim => claim.Type == ClaimTypes.Role && claim.Value == "Admin")) 
                { 
                    //TODO: Validar si el id enviado por parametro es igual al id del usuario enviado en el token.
                    if (false) 
                    { 
                        throw new Exception("El token no es propio");
                    }
                }

                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                var settings = new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    },
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                var result = JsonConvert.SerializeObject(ex.Message, settings);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
                await context.Response.WriteAsync(result);
            }
        }
    }
}
