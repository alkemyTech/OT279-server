using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationsBusiness _organizationsService;

        public OrganizationsController(IOrganizationsBusiness service)
        {
            _organizationsService = service;
        }

        [HttpGet("/api/organization/public")]
        
        public  async Task<IActionResult> GetAllOrganization()
        {
            try
            {
                var organization = await _organizationsService.GetAllOrganization();
                if(organization.Count > 0) return Ok(organization);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdOrganization(int id)
        {
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrganization([FromBody] Organization organization)
        {
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrganization(int id, [FromBody] Organization organization)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization(int id)
        {
            return NoContent();
        }


    }
}
