using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barber.Dtos;
using Barber.Interfaces;
using Barber.Models;
using Microsoft.AspNetCore.Mvc;

namespace Barber.Controllers
{
    [ApiController]
    [Route("v1")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("users")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var result = await _service.CreateUserAsync(user);
            if (user == null) return BadRequest("Invalid Name");

            return Ok(result);

        }

        [HttpDelete("users/{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _service.DeleteUserByIdAsync(id);
            if (!result) return NotFound("Invalid ID");

            return NoContent();
        }

        [HttpGet("users/{id:int}")]
        public async Task<IActionResult> FindUserById(int id)
        {
            var result = await _service.GetUserByIdAsync(id);
            if (result == null) return NotFound("Invalid Id");

            return Ok(result);
        }

        [HttpPut("users/{id:int}")]
        public async Task<IActionResult> UpdateUserById(int id, User userup)

        {
            var result = await _service.UpdateUserByIdAsync(id, userup);
            if (!result) return BadRequest();

            return Ok(result);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _service.GetAllUsersAsync();
            return Ok("Usuario atualizado com sucesso!");
        }
    }

}