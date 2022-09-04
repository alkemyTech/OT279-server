using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using OngProject.Core.Models.DTOs.UserDTO;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsBusiness _commentsBusiness;
        public CommentsController(ICommentsBusiness service)
        {
            _commentsBusiness = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            try
            {
                var comments = await _commentsBusiness.GetAll();
                if (comments == null) return NotFound();
                return Ok(comments);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveComments([FromQuery(Name = "id")] int id, [FromBody] string strToken)
        {
            try
            {
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(strToken);
                string userId = jwt.Claims.First(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
                string role = jwt.Claims.First(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
                      
                var comments = await _commentsBusiness.GetById(id);

                if (comments != null)
                {

                    if (comments.UserId.ToString() == userId || role == "Admin")
                    {
                        if (comments != null)
                        {
                            var flag = await _commentsBusiness.DeleteComments(comments);
                            return Ok(flag);
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
                    else
                    {
                        return Forbid();
                    }
                }

                return NotFound();

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
