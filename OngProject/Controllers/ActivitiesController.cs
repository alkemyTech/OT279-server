using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs.ActivitiesDTO;
using OngProject.Entities;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesBusiness _service;
        public ActivitiesController(IActivitiesBusiness service)
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
        public async Task<IActionResult> CreateActivities([FromQuery] ActivitiesCreateDTO activitiesDTO)
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
        public async Task<IActionResult> UpdateActivities([FromQuery(Name = "id")] int id, [FromQuery] ActivitiesCreateDTO activitiesDTO)
        {
            var existActivityByID = await _service.GetActivitiesById(id);
            if (existActivityByID != null)
            {
                var activitiesUpdated = await _service.UpdateActivities(id, activitiesDTO);
                ActivitiesMapper mapper = new();
                var dto = mapper.FromActivitiesToActivitiesDisplayDto(activitiesUpdated);
                return Ok(dto);
            }
            else
            {
                return NotFound("No se encontro una actividad con ese ID");
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetActivitiesById([FromQuery(Name = "id")] int id)
        {

            var activities = await _service.GetActivitiesById(id);

            if (activities != null)
            {
                ActivitiesMapper mapper = new();
                var activity = mapper.FromActivitiesToActivitiesDisplayDto(activities);
                return Ok(activity);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
