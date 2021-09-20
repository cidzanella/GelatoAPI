using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GelatoAPI.Data;
using GelatoAPI.Models;
using GelatoAPI.Interfaces;
using GelatoAPI.Extensions;
using GelatoAPI.DTOs;

namespace GelatoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RawMaterialsController : ControllerBase
    {
        private readonly IRawMaterialService _rawMaterialService;

        public RawMaterialsController(IRawMaterialService rawMaterialService)
        {
            _rawMaterialService = rawMaterialService;
        }

        // GET: api/RawMaterials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RawMaterial>>> GetRawMaterials()
        {
            var rawMaterials = await _rawMaterialService.ReadRawMaterialsAsync();

            if (rawMaterials == null) 
                return NotFound();

            return Ok(rawMaterials);
        }

        // GET: api/RawMaterials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RawMaterial>> GetRawMaterial(int id)
        {
            var response = await _rawMaterialService.ReadRawMaterialAsync(id);

            if (! response.Success ) 
                return NotFound(response.Message);

            return Ok(response.RawMaterialDto);
        }

        // POST: api/RawMaterials
        [HttpPost]
        public async Task<ActionResult<RawMaterial>> PostRawMaterial(RawMaterialDTO rawMaterialDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var response = await _rawMaterialService.CreateRawMaterialAsync(rawMaterialDto);

            if (!response.Success)
                return BadRequest($"{response.Message}: {response.HttpResponseCode}");

            return Ok(response.RawMaterialDto);
        }

        // PUT: api/RawMaterials/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRawMaterial(int id, RawMaterialDTO rawMaterialDto)
        {
            if (id != rawMaterialDto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var response = await _rawMaterialService.UpdateRawMaterialAsync(rawMaterialDto);

            if (!response.Success)
                return BadRequest($"{response.Message}: {response.HttpResponseCode}");

            return Ok(rawMaterialDto);
        }

        // DELETE: api/RawMaterials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRawMaterial(int id)
        {
            var response = await _rawMaterialService.DeleteRawMaterialAsync(id);

            if (!response.Success)
                return BadRequest($"{response.Message}: {response.HttpResponseCode}");

            return NoContent();
        }


        [HttpGet]
        [Route("GetRawMaterialTypes/")]
        public async Task<IEnumerable<RawMaterialType>> GetRawMaterialTypes()
        {
            return await _rawMaterialService.ReadRawMaterialTypesAsync();
        }

        [HttpGet]
        [Route("GetRawMaterialSuppliers/")]
        public async Task<IEnumerable<RawMaterialSupplier>> GetRawMaterialSuppliers()
        {
            return await _rawMaterialService.ReadRawMaterialSuppliersAsync();
        }
    }
}
