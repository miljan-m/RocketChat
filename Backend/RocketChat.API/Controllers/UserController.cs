using Microsoft.AspNetCore.Mvc;
using RocketChat.Application.DTOs.UserDTOs;
using RocketChat.Application.Interfaces;
using RocketChat.Application.Services;

namespace RocketChat.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {

        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserDTO>> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            var result = await _userService.CreateUser(createUserDTO);
            if (result == null) return NoContent();
            return result;
        }


        [HttpGet("{UserId}")]
        public async Task<ActionResult<GetUserDTO>> GetUser([FromRoute] Guid UserId)
        {
            var result = await _userService.GetUser(UserId);
            if (result == null) return NotFound();
            return result;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDTO>>> GetUsers()
        {
            var result = await _userService.GetAllUsers();
            if (result == null) return NotFound();
            return Ok(result);
        }


        [HttpDelete("{UserId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid UserId)
        {
            var result = await _userService.DeleteUser(UserId);
            if (result == null) return NotFound();
            return Ok(result);
        }


        [HttpPatch]
        public Task<IActionResult> UpdateUser([FromRoute] Guid UserId, [FromBody] UpdateUserDTO updateUserDTO)
        {
            return null;
        }

    }
}