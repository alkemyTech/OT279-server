using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersService _membersService;
        public MembersController(IMembersService membersService)
        {
            _membersService = membersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await _membersService.GetAllMembers();

            if(members != null)
            {
                return Ok(members);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember([FromBody] MemberDTO memberDTO)
        {
            var member = await _membersService.CreateMember(memberDTO);

            if(member != null)
            {
                return Ok(member);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveMember(int Id)
        {
            bool member = await _membersService.DeleteMember(Id);
            if (member)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMember(int Id, MemberDTO memberDTO)
        {
            var member = await _membersService.UpdateMember(Id, memberDTO);
            if(member != null)
            {
                return Ok(member);
            }
            else
            {
                return NotFound(400);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetMemberById(int Id)
        {
            var member = await _membersService.GetMemberById(Id);
            if(member != null)
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
