using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(IUsersBusiness service, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var user = await _service.GetAll();

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User userDTO)
        {
            var user = await _service.Insert(userDTO);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("auth/login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDTO userLoginDTO)
        {
            // 1. Valido si el campo email y password fueron enviados correctamente
            if (!ModelState.IsValid)
            {
                return BadRequest(string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)));
            }
            else
            {
                // 2. Verifico si existe un usuario con el mail ingresado
                var user = await _userManager.FindByEmailAsync(userLoginDTO.Email);
                if (user == null)
                {
                    return BadRequest("No existe un usuario con el mail ingresado");
                }
                else
                {
                    /*
                        3. Si existe usuario con el mail ingresado, comparar passwords encriptadas 
                    
                    string encryptedPassword = nombreMetodoEncripte(userLoginDTO.Password)
                    if (user.Password == encryptedPassword) 
                    { 
                        return Ok(await GetToken(user));
                    } 
                    else 
                    { 
                        return Ok("Ocurrio un error al intentar logearse"); 
                    }
                     */
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
