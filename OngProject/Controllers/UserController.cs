using Microsoft.AspNetCore.Authorization;
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
        private readonly IAuthBusiness _authBusiness;
        private readonly ISendGridBusiness _sendGridBusiness;

        public UserController(IUsersBusiness service, IAuthBusiness authBusiness, ISendGridBusiness sendGridBusiness)
        {
            _service = service;
            _authBusiness = authBusiness;
            _sendGridBusiness = sendGridBusiness;
        }

        [Authorize(Roles = "Administrador")]
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
                var token = await _service.Insert(userDTO);
                if (token != null)
                {
                    //var userDB = await _service.GetByEmail(user.Email);
                    //var token = _authBusiness.GetToken(userDB);
                    await _sendGridBusiness.WelcomeEmail(userDTO.Email);
                    return Ok(token);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost("/auth/login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDTO userLoginDTO)
        {
            // 1. Valida si el campo email y password fueron enviados correctamente en la peticion
            if (!ModelState.IsValid)
            {
                return BadRequest(string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)));
            }
            else
            {
                // 2. Verifica si existe un usuario con el mail ingresado
                var userToLogin = await _service.GetByEmail(userLoginDTO.Email);
                if (userToLogin == null)
                {
                    return BadRequest("No existe un usuario con el mail ingresado");
                }
                else
                {
                    //3. Si existe usuario con el mail ingresado, comparar passwords encriptadas 
                    var user = await _service.ValidateUser(userToLogin, userLoginDTO.Password);
                    //4. Si la password ingresada es correcta, retorna el token otorgado al usuario, por lo contrario retorna false. 
                    if (user == null)
                    {
                        return Ok(false);
                    }
                    return Ok(_authBusiness.GetToken(user));
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
