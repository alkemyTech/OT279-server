using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Entities;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private IActivitiesService _service;
        public ActivitiesController(IActivitiesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActivities()
        {

            var activities = await _service.GetAllActivities();

            if (activities != null)
            {
                return Ok(activities);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateActivities([FromBody] Activities activitiesDTO)
        {

            var activities = await _service.CreateActivities(activitiesDTO);

            if (activities != null)
            {
                return Ok(activities);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete]
        public async Task<IActionResult> RemoveActivities([FromQuery(Name = "id")] int id)
        {

            bool activities = await _service.RemoveActivities(id);

            if (activities)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateActivities([FromQuery(Name = "id")] int id, [FromBody] Activities activitiesDTO)
        {
            var activities = await _service.UpdateActivities(id, activitiesDTO);
            if (activities != null)
            {
                return Ok(activities);
            }
            else
            {
                return NotFound(400);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetActivitiesById([FromQuery(Name = "id")] int id)
        {

            var activities = await _service.GetActivitiesById(id);

            if (activities != null)
            {
                return Ok(activities);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
