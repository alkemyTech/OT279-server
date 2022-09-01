using Microsoft.AspNetCore.Http;
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
    public class ContactsController : ControllerBase
    {
        private readonly IContactsBusiness _contactsBusiness;
        public ContactsController(IContactsBusiness business)
        {
            _contactsBusiness = business;
        }

        //[Authorize(Roles = "Administrador")]
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

        [HttpPost]
        public async Task<IActionResult> PostContacts([FromForm] ContactCreateDTO contactDto)
        {
            var contact = await _contactsBusiness.CreateContact(contactDto);
            if(contact != null)
            {
                return Ok(contact);
            }
            else
            {
                return NotFound();
            }
        }

    }
}