using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GelatoAPI.Data;
using GelatoAPI.Models;
using GelatoAPI.Interfaces;
using GelatoAPI.DTOs;
using GelatoAPI.Extensions;

namespace GelatoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SorbettoTypesController : ControllerBase
    {
        private readonly ISorbettoTypeService _sorbettoTypeService;

        public SorbettoTypesController(ISorbettoTypeService sorbettoTypeService)
        {
            _sorbettoTypeService = sorbettoTypeService;
        }

        // GET: api/SorbettoTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SorbettoTypeDTO>>> GetSorbettoTypes()
        {
            var sorbettoTypes = await _sorbettoTypeService.ReadSorbettoTypesAsync();

            if (sorbettoTypes == null)
                return NotFound();

            return Ok(sorbettoTypes);
        }

        // GET: api/SorbettoTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SorbettoTypeDTO>> GetSorbettoType(int id)
        {
            var response = await _sorbettoTypeService.ReadSorbettoTypeAsync(id);    

            if (!response.Success)
            {
                return NotFound(response.Message);
            }

            return Ok(response.SorbettoTypeDto);
        }

        // POST: api/SorbettoTypes
        [HttpPost]
        public async Task<ActionResult<SorbettoTypeDTO>> PostSorbettoType(SorbettoTypeCreateDTO sorbettoTypeCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var response = await _sorbettoTypeService.CreateSorbettoTypeAsync(sorbettoTypeCreateDto);

            if (!response.Success)
                return BadRequest($"{response.Message}: {response.HttpResponseCode}");

            return Ok(response.SorbettoTypeDto);
        }

        // PUT: api/SorbettoTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSorbettoType(int id, SorbettoTypeDTO sorbettoTypeDto)
        {
            if (id != sorbettoTypeDto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var response = await _sorbettoTypeService.UpdateSorbettoTypeAsync(id, sorbettoTypeDto);

            if (!response.Success)
                return BadRequest($"{response.Message}: {response.HttpResponseCode}");

            return Ok(response.SorbettoTypeDto);
        }

        // DELETE: api/SorbettoTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSorbettoType(int id)
        {
            var response = await _sorbettoTypeService.DeleteSorbettoTypeAsync(id);

            if (!response.Success)
                return BadRequest($"{response.Message}: {response.HttpResponseCode}");

            return NoContent();
        }

    }
}
