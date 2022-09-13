using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Models.DTOs.OrganizationDTO;
using OngProject.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationsBusiness _organizationsService;

        public OrganizationsController(IOrganizationsBusiness service)
        {
            _organizationsService = service;
        }

        [HttpGet("/api/organization/public")]

        public async Task<IActionResult> GetAllOrganization()
        {
            var organizations = await _organizationsService.GetAllOrganization();
            return Ok(organizations);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("organization/public/{id}")]
        public async Task<IActionResult> UpdateOrganization(int id, [FromBody] UpdateOrganizationDTO updateOrganizationDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)));
                }
                else
                {
                    var result = await _organizationsService.UpdateOrganization(id, updateOrganizationDTO);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
