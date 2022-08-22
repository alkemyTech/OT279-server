using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationsService _organizationsService;

        public OrganizationsController(IOrganizationsService organizationsService)
        {
            _organizationsService = organizationsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrganization()
        {
            var allOrganizations = await _organizationsService.GetAllOrganization();
            if(allOrganizations != null)
            {
                return Ok(allOrganizations);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdOrganization(int id)
        {
            var organizationById = await _organizationsService.GetByIdOrganization(id);
            if(organizationById != null)
            {
                return Ok(organizationById);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrganization([FromBody] Organization organization)
        {
            var newOrganization = await _organizationsService.InsertOrganization(organization);
            if(newOrganization != null)
            {
                return Ok(newOrganization);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrganization(int id, [FromBody] Organization organization)
        {
            var updateOrganization = await _organizationsService.UpdateOrganization(id, organization);
            if(updateOrganization != null)
            {
                return Ok(updateOrganization);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization(int id)
        {
            bool Result = await _organizationsService.DeleteOrganization(id);
            if (Result)
            {
                return Ok("Se elimino la Organizacion");
            }
            return BadRequest();
        }


    }
}
