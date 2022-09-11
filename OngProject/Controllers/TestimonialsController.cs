using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs.PagedListDTO;
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
        public async Task<IActionResult> GetAllTestimonials([FromQuery(Name = "numberPage")] int numberPage = 1, [FromQuery(Name = "quantityPage")] int quantityPage = 10)
        {
            var host = HttpContext.Request.Host.Value;
            var path = HttpContext.Request.Path.Value;

            var testDto = await _service.GetAll();

            if (testDto != null)
            {
                PagedListHelper<TestimonialsDTO> paged = PagedListHelper<TestimonialsDTO>.Create(testDto, numberPage, quantityPage);
                PagedListDTO<TestimonialsDTO> testList = new(paged, host, path);
                return Ok(testList);
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

        [HttpDelete("/testimonials/")]
        public async Task<IActionResult> RemoveTestimonials([FromQuery(Name = "id")] int id)
        {

            var testimonials = await _service.GetById(id);

            if (testimonials != null)
            {
                var flag = await _service.DeleteTestimonials(testimonials);
                return Ok(flag);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTestimonials([FromRoute] int id, [FromForm] TestimonialUpdateDto testDTO)
        {
            var testimonial = await _service.GetById(id);
            if (testimonial != null)
            {
                var testimonialUpdated = await _service.UpdateTestimonials(id, testDTO);
                TestimonialsMapper mapper = new();
                var testimonialDTO = mapper.FromTestimonialsToTestimonialsDisplayDTO(testimonialUpdated);
                return Ok(testimonialDTO);
            }
            else
            {
                return NotFound("No se encontro un testimonio con ese ID");
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
