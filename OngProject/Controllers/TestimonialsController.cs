using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs.TestimonialDTO;
using OngProject.Entities;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialsBusiness _service;
        public TestimonialsController(ITestimonialsBusiness service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTestimonials()
        {

            var test = await _service.GetAll();

            if (test != null)
            {
                return Ok(test);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonials([FromForm] TestimonialInsertDto testDTO)
        {
            try
            {
                var test = await _service.Insert(testDTO);
                return Ok(test);
            }
            catch (System.Exception err)
            {
                return NotFound(err.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTestimonials([FromQuery(Name = "id")] int id)
        {

            bool test = await _service.Delete(id);

            if (test)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonials([FromQuery(Name = "id")] int id, [FromBody] Testimonials testDTO)
        {
            var test = await _service.Update(id, testDTO);
            if (test != null)
            {
                return Ok(test);
            }
            else
            {
                return NotFound(400);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetTestimonialsById([FromQuery(Name = "id")] int id)
        {

            var test = await _service.GetById(id);

            if (test != null)
            {
                return Ok(test);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
