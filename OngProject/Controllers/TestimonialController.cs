using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _service;
        public TestimonialController(ITestimonialService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTestimonials()
        {
            try
            {

                var testimonials = _service.GetAll();

                if (testimonials != null)
                {
                    return Ok(testimonials);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonials([FromBody] Testimonials testimonials)
        {

            try
            {
                await _service.Insert(testimonials);
                return Ok(new {menssge="guardado!"});
            }
            catch (System.Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTestimonials( int id, [FromBody] Testimonials testimonials)
        {
            try
            {
                await _service.Update(id, testimonials);
                return Ok(new { menssge = "Actualizado!" });
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex);
            }
           
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> GetCategoryById( int id)
        {

            try
            {
                await _service.Delete(id);
                return Ok(new { menssge = "eliminado!" });
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex);
            }

            

        }

    }
    
}
