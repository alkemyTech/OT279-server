using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
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
        public async Task<IActionResult> CreateMember(MembersDTO memberDTO, string name)
        {
            if(name != null && name != "" && memberDTO.Name == name)
            {
                var newMember = await _membersBusiness.CreateMember(memberDTO);
                if(newMember)
                    return Ok("Member created");
                else
                    return NotFound("Something went wrong");
            }
            else
                return NotFound("The name is required");

        }

        [HttpDelete]
        public async Task<IActionResult> RemoveMember()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMember()
        {
            throw new NotImplementedException();
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetMemberById()
        {
            throw new NotImplementedException();
        }
    }
}