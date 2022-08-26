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
                List<CommentGetDto> listComment = new();
                var comments = await _service.GetAll();
  
                if (comments == null) return NotFound();
                foreach (var comment in comments)
                {
                    CommentGetDto commentDto = new()
                    {
                        Body = comment.Body
                    };
                    listComment.Add(commentDto);
                }
                return Ok(listComment);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
