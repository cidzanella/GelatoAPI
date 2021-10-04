using GelatoAPI.Data;
using GelatoAPI.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class BuggyTestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BuggyTestController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> TestAuthorizedAccess()
        {
            return "authorized";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> TestNotFoundItem()
        {
            var item = _context.Users.Find(-1);

            if (item == null) return NotFound();

            return Ok(item);
        }

        [HttpGet("server-error")]
        public ActionResult<string> TestServerError()
        {
            var item = _context.Users.Find(-1);

            // generate an error converting NULL to string
            var itemToReturn = item.ToString();

            return Ok(itemToReturn);
        }

        [HttpGet("bad-request")]
        public ActionResult<string> TestBadRequest()
        {
            return BadRequest("This was a poor request");
        }
    }

}
