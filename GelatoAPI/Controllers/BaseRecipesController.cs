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
    public class BaseRecipesController : ControllerBase
    {
        private readonly IBaseRecipeService _baseRecipeService;

        public BaseRecipesController(IBaseRecipeService baseRecipeService)
        {
            _baseRecipeService = baseRecipeService;
        }

        // GET: api/BaseRecipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseRecipeDTO>>> GetBaseRecipes()
        {
            var baseRecipes = await _baseRecipeService.ReadBaseRecipesAsync();

            if (baseRecipes == null)
                return NotFound();

            return Ok(baseRecipes);
        }

        // GET: api/BaseRecipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRecipeDTO>> GetBaseRecipe(int id)
        {
            var response = await _baseRecipeService.ReadBaseRecipeAsync(id);


            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.BaseRecipeDto);
        }

        [HttpGet("byBaseType/{id}")]
        public async Task<ActionResult<IEnumerable<BaseRecipeDTO>>> GetBaseRecipeByBaseType(int id)
        {
            var baseRecipes = await _baseRecipeService.ReadBaseRecipesByBaseTypeAsync(id);

            if (baseRecipes == null)
                return NotFound();

            return Ok(baseRecipes);

        }

        // GET: api/BaseTypes
        [HttpGet("basetypes")]
        public async Task<ActionResult<IEnumerable<BaseTypeDTO>>> GetBaseTypes()
        {
            var baseTypes = await _baseRecipeService.ReadBaseTypesAsync();
            if (baseTypes == null)
                return NotFound();

            return Ok(baseTypes);
        }

        // PUT: api/BaseRecipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaseRecipe(int id, BaseRecipeUpdateDTO baseRecipeUpdateDto)
        {
            if (id != baseRecipeUpdateDto.Id)
            {
                return BadRequest();
            }

            var response = await _baseRecipeService.UpdateBaseRecipeAsync(baseRecipeUpdateDto);

            if (!response.Success)
                return BadRequest($"{response.Message}: {response.HttpResponseCode}");

            return Ok(response.BaseRecipeDto);
        }

        // POST: api/BaseRecipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BaseRecipe>> PostBaseRecipe(BaseRecipeCreateDTO baseRecipeCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var response = await _baseRecipeService.CreateBaseRecipeAsync(baseRecipeCreateDto);

            if (!response.Success)
                return BadRequest($"{response.Message}: {response.HttpResponseCode}");

            return Ok(response.BaseRecipeDto);
        }

        // DELETE: api/BaseRecipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaseRecipe(int id)
        {
            var response = await _baseRecipeService.DeleteBaseRecipeAsync(id);

            if (!response.Success)
                return BadRequest($"{response.Message}: {response.HttpResponseCode}");

            return NoContent();
        }
    }
}
