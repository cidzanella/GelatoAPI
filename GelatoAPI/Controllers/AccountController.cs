using GelatoAPI.DTOs;
using GelatoAPI.Interfaces;
using GelatoAPI.Models;
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
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<ActionResult<AppUser>> Register(RegisterDTO registerDto)
        {

        }

        public async Task<ActionResult<AppUser>> Login(LoginDTA loginDto)
        {

        }
    }
}
