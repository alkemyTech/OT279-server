using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersBusiness _membersBusiness;
        public MembersController(IMembersBusiness membersService)
        {
            _membersBusiness = membersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember()
        {
            throw new NotImplementedException();
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
