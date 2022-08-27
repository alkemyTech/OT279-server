using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsBusiness _contactsBusiness;
        public ContactsController(IContactsBusiness business)
        {
            _contactsBusiness = business;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            var contactsDTO = await _contactsBusiness.GetAllContacts();

            if (contactsDTO != null)
            {
                return Ok(contactsDTO);
            }
            else
            {
                return NotFound();
            }
        }

    }
}