using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsBusiness _service;
        public CommentsController(ICommentsBusiness service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            try
            {
                var comments = await _service.GetAll();
                if (comments == null) return NotFound();
                return Ok(comments);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
