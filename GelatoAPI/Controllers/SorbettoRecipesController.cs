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
    public class SorbettoRecipesController : ControllerBase
    {
        private readonly ISorbettoRecipeService _sorbettoRecipeService;

        public SorbettoRecipesController(ISorbettoRecipeService sorbettoRecipeService)
        {
            _sorbettoRecipeService = sorbettoRecipeService;
        }

        // GET: api/SorbettoRecipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SorbettoRecipeDTO>>> GetSorbettoRecipes()
        {
            var sorbettoRecipes = await _sorbettoRecipeService.ReadSorbettoRecipesAsync();

            if (sorbettoRecipes == null)
                return NotFound();

            return Ok(sorbettoRecipes); 
        }

        // retrieve one item of a recipe by item id
        // GET: api/SorbettoRecipes/Item/5
        [HttpGet("Item/{id}")]
        public async Task<ActionResult<SorbettoRecipeDTO>> GetSorbettoRecipeItem(int id)
        {
            var response = await _sorbettoRecipeService.ReadSorbettoRecipeItemAsync(id);

            if (!response.Success)
            {
                return NotFound(response.Message);
            }

            return Ok(response.SorbettoRecipeDto);
        }

        // Retrieve all the itens of a sorbetto recipe specified by sorbetto type id
        // GET: api/SorbettoRecipe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SorbettoRecipeDTO>>> GetSorbettoRecipe(int id)
        {
            var sorbettoRecipe = await _sorbettoRecipeService.ReadSorbettoRecipeBySorbettoTypeAsync(id);

            if (sorbettoRecipe == null)
            {
                return NotFound();
            }

            return Ok(sorbettoRecipe);

        }

        // Update one item of a recipe
        // PUT: api/SorbettoRecipes/Item/5
        [HttpPut("Item/{id}")]
        public async Task<IActionResult> PutSorbettoRecipeItem(int id, SorbettoRecipeDTO sorbettoRecipeDto)
        {
            if (id != sorbettoRecipeDto.Id)
            {
                return BadRequest();
            }

            var response = await _sorbettoRecipeService.UpdateBaseRecipeItemAsync(sorbettoRecipeDto);

            if (!response.Success)
                return BadRequest($"{response.Message}: {response.HttpResponseCode}");

            return Ok(response.SorbettoRecipeDto);

        }

        // add an item to a recipe
        // POST: api/SorbettoRecipes/Item
        [HttpPost("Item/")]
        public async Task<ActionResult<SorbettoRecipe>> PostSorbettoRecipeItem(SorbettoRecipeCreateDTO sorbettoRecipeCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var response = await _sorbettoRecipeService.CreateBaseRecipeItemAsync(sorbettoRecipeCreateDto);

            if (!response.Success)
                return BadRequest($"{response.Message}: {response.HttpResponseCode}");

            return Ok(response.SorbettoRecipeDto);
        }

        // delete one recipe item by item id
        // DELETE: api/SorbettoRecipes/Item/5
        [HttpDelete("Item/{id}")]
        public async Task<IActionResult> DeleteSorbettoRecipeItem(int id)
        {
            var response = await _sorbettoRecipeService.DeleteBaseRecipeItemAsync(id);

            if (!response.Success)
                return BadRequest($"{response.Message}: {response.HttpResponseCode}");

            return NoContent();

        }

        // delete all itens of a given sorbetto type recipe: example: delete fragola
        // DELETE: api/SorbettoRecipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSorbettoRecipe(int id)
        {
            var response = await _sorbettoRecipeService.DeleteBaseRecipeBySorbettoTypeAsync(id);

            if (!response.Success)
                return BadRequest($"{response.Message}: {response.HttpResponseCode}");

            return NoContent();
        }

    }
}
