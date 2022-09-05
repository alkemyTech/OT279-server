using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
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
            var organizations = await _organizationsService.GetAllOrganization();
            return Ok(organizations);
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
