using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs.UserDTO;
using OngProject.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBusiness _authBusiness;
        private readonly IUsersBusiness _UserBusiness;

        public AuthController (IAuthBusiness authBusiness, IUsersBusiness UserBusiness)
        {
            _authBusiness = authBusiness;
            _UserBusiness = UserBusiness;
        }

        [HttpGet]
        [Route("me")]
        public async Task<IActionResult> getUserByAuth(string strToken)
        {
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(strToken);
            var userId = int.Parse(jwt.Claims.First(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
            var user = await _UserBusiness.GetById(userId);
            if (user != null)
            {
                    ViewUserDTO viewUser = new(user)
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Photo = user.Photo,
                    Role = user.Role

                };
                return Ok(viewUser);
            }
            return NotFound();
            
        }

    }
}
