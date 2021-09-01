using GelatoAPI.DTOs;
using GelatoAPI.Extensions;
using GelatoAPI.Interfaces;
using GelatoAPI.Models;
using GelatoAPI.Services.Communications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _accountService;

        public AuthController(IAuthService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Login(UserLoginDTO loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            UserResponse response = await _accountService.Login(loginDto);
            
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.UserDto);
        }

        //public async Task<ActionResult<AppUser>> Register(RegisterDTO registerDto)
        //{

        //}

    }
}
