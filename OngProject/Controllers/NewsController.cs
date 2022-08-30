using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Entities;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        private readonly INewsBusiness _service;

        public NewsController(INewsBusiness service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNews()
        {

            var news = await _service.GetAllNews();

            if (news != null)
            {
                return Ok(news);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateNews([FromBody] News newsDTO)
        {

            var news = await _service.CreateNews(newsDTO);

            if (news != null)
            {
                return Ok(news);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete]
        public async Task<IActionResult> RemoveNews([FromQuery(Name = "id")] int id)
        {

            bool news = await _service.RemoveNews(id);

            if (news)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateNews([FromQuery(Name = "id")] int id, [FromBody] News newsDTO)
        {
            var news = await _service.UpdateNews(id, newsDTO);
            if (news != null)
            {
                return Ok(news);
            }
            else
            {
                return NotFound(400);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetNewById([FromQuery(Name = "id")] int id)
        {

            var news = await _service.GetNewsById(id);

            if (news != null)
            {
                return Ok(news);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet("{id}/comments")]
        public async Task<IActionResult> GetNewByIdComments( int id)
        {
            var news = await _service.GetNewsByIdComments(id);

            if (news != null)
            {  
                return Ok(news);
            }
            else
            {
                return NotFound();
            }

        }

    }
}
