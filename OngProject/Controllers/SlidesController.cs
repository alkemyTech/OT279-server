using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Core.Models.DTOs;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidesController : ControllerBase
    {

        private readonly ISlidesBusiness _service;

        public SlidesController(ISlidesBusiness service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSlides()
        {

            var slides = await _service.GetAllSlides();

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
        public async Task<IActionResult> CreateSlide([FromBody] Slides slidesDTO)
        {

            var slide = await _service.CreateSlide(slidesDTO);

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
        public async Task<IActionResult> RemoveSlide([FromQuery(Name = "id")] int id)
        {

            bool slide = await _service.RemoveSlide(id);

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
        public async Task<IActionResult> UpdateSlide([FromQuery(Name = "id")] int id, [FromBody] Slides slidesDTO)
        {
            var slide = await _service.UpdateSlide(id, slidesDTO);
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
        public async Task<IActionResult> GetSlideById([FromQuery(Name = "id")] int id)
        {

            var slide = await _service.GetSlideById(id);

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
