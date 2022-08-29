﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs.UserDTO;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersBusiness _service;

        public UserController(IUsersBusiness service)
        {
            _service = service;
        }

        //[Authorize(Roles = "Administrador")]
        [HttpGet]
        [Route("/users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var _listUsers = await _service.GetAll();
            if (_listUsers.Count > 0)
            {
                return Ok(_listUsers);
            }
            else
            {
                return NoContent();
            }
        }



        [HttpPost("/auth/register")]
        public async Task<IActionResult> CreateUser([FromBody] UserRegisterDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)));
            }
            else
            {
                var user = await _service.Insert(userDTO);
                if (user != null)
                {
                    var token = _service.GetToken(user);
                    return Ok(token);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUser([FromQuery(Name = "id")] int id)
        {

            bool user = await _service.Delete(id);

            if (user)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromQuery(Name = "id")] int id, [FromBody] User userDTO)
        {
            var user = await _service.Update(id, userDTO);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound(400);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUserById([FromQuery(Name = "id")] int id)
        {

            var user = await _service.GetById(id);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }

        }

    }
}
