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

        private readonly INewsService _service;

        public NewsController(INewsService service)
        {
            _service = service;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAllNews()
        {

            var slides = await _service.GetAllNews();

            if (slides != null)
            {
                return Ok(slides);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateNews([FromBody] News newsDTO)
        {

            var slide = await _service.CreateNews(newsDTO);

            if (slide != null)
            {
                return Ok(slide);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete]
        public async Task<IActionResult> RemoveNews([FromQuery(Name = "id")] int id)
        {

            bool slide = await _service.RemoveNews(id);

            if (slide)
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
            var slide = await _service.UpdateNews(id, newsDTO);
            if (slide != null)
            {
                return Ok(slide);
            }
            else
            {
                return NotFound(400);
            }
         }

        [HttpGet("id")]
        public async Task<IActionResult> GetNewsById([FromQuery(Name = "id")] int id)
        {

            var slide = await _service.GetNewsById(id);

            if (slide != null)
            {
                return Ok(slide);
            }
            else
            {
                return NotFound();
            }

        }

    }
}
