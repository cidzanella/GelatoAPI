using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GelatoAPI.Data;
using Microsoft.AspNetCore.Authorization;
using GelatoAPI.Interfaces;
using GelatoAPI.Extensions;
using GelatoAPI.DTOs;

namespace GelatoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUserService _userService;

        public UsersController(AppDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        // GET: api/Users
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userService.ReadUsersAsync();

            if (users == null) return NotFound();

            return Ok(users);
        }

        // GET: api/Users/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            if (id <=0 )
                return BadRequest("Not a valid ID parameter value.");
            
            var response = await _userService.ReadUserAsync(id);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.UserDto);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [Authorize]
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(UserRegisterDTO user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var response = await _userService.CreateUserAsync(user);

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.UserDto);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserUpdateDTO userUpdateDto)
        {
            if (id != userUpdateDto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var response = await _userService.UpdateUserAsync(userUpdateDto);

            if (!response.Success)
                return BadRequest($"{response.Message}: {response.HttpResponseCode}");

            return Ok(response.UserDto);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUser(int id)
        {
            {

                var response = await _userService.DeleteUserAsync(id);
                if (!response.Success)
                    return BadRequest($"{response.Message}: {response.HttpResponseCode}");

                return NoContent();
            }
        }

    }
}
