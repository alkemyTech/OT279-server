using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs.PagedListDTO;
using System.Linq;
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
        public async Task<IActionResult> GetAllMembers([FromQuery(Name = "numberPage")] int numberPage = 1, [FromQuery(Name = "quantityPage")] int quantityPage = 10)
        {
            var host = HttpContext.Request.Host.Value;
            var path = HttpContext.Request.Path.Value;
            var membersDTO = await _membersBusiness.GetAllMembers();
            if (membersDTO != null)
            {
                PagedListHelper<MembersDTO> paged = PagedListHelper<MembersDTO>.Create(membersDTO, numberPage, quantityPage);
                PagedListDTO<MembersDTO> memberList = new(paged,host,path);
                return Ok(memberList);
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