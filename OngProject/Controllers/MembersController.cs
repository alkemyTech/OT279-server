using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Entities;
using System;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersBusiness _membersBusiness;
        public MembersController(IMembersBusiness service)
        {
            _membersBusiness = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            var membersDTO = await _membersBusiness.GetAllMembers();

            if (membersDTO != null)
            {
                return Ok(membersDTO);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember(MembersDTO memberDTO)
        {
            var newMember = await _membersBusiness.CreateMember(memberDTO);
            if (newMember)
                return Ok("Member created " + newMember);
            else
                return NotFound("Something went wrong");

        }

        [HttpDelete]
        public async Task<IActionResult> RemoveMember([FromQuery(Name = "id")] int id)
        {
            var members = await _membersBusiness.GetMemberById(id);

            if (members != null)
            {
                var flag = await _membersBusiness.DeleteMember(members);
                return Ok(flag);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMembers([FromRoute] int id, [FromForm] MembersUpdateDTO membersUpdateDTO)
        {
            var member = await _membersBusiness.GetMemberById(id);
            if (member != null)
            {
                var memberUpdated = await _membersBusiness.UpdateMembers(id, membersUpdateDTO);
                MembersMapper mapper = new();
                var membersDTO = mapper.FromMembersToMembersDisplayDTO(memberUpdated);
                return Ok(membersDTO);
            }
            else
            {
                return NotFound("No se encontro un miembro con ese ID");
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetMemberById([FromQuery(Name = "id")] int id)
        {
            var member = await _membersBusiness.GetMemberById(id);

            if (member != null)
            {
                return Ok(member);
            }
            else
            {
                return NotFound();
            }

        }
    }
}