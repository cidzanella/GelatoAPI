using GelatoAPI.DTOs;
using GelatoAPI.Extensions;
using GelatoAPI.Interfaces;
using GelatoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GelatoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GelatoRecipesController : ControllerBase
    {
        private readonly IGelatoRecipeService _gelatoRecipeService;

        public GelatoRecipesController(IGelatoRecipeService gelatoRecipeService)
        {
            _gelatoRecipeService = gelatoRecipeService;
        }

        // GET: api/<GelatoRecipesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GelatoRecipeDTO>>> GetGelatoRecipes()
        {
            var gelatoRecipes = await _gelatoRecipeService.ReadGelatoRecipesAsync();

            if (gelatoRecipes == null)
                return NotFound();

            return Ok(gelatoRecipes);
        }

        // GET api/<GelatoRecipesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GelatoRecipeDTO>> GetGelatoRecipe(int id)
        {
            var response = await _gelatoRecipeService.ReadGelatoRecipeAsync(id);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.GelatoRecipeDto);
        }

        // POST api/<GelatoRecipesController>
        [HttpPost]
        public async Task<ActionResult<GelatoRecipeDTO>> PostGelatoRecipe([FromBody] GelatoRecipeCreateDTO gelatoRecipeCreateDto)
        {
            if (!ModelState.IsValid)
                return  BadRequest(ModelState.GetErrorMessages());

            var response = await _gelatoRecipeService.CreateGelatoRecipeAsync(gelatoRecipeCreateDto);

            if (!response.Success)
                return BadRequest($"{response.Message}: {response.HttpResponseCode}");

            return Ok(response.GelatoRecipeDto);
        }

        // PUT api/<GelatoRecipesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutGelatoRecipe(int id, [FromBody] GelatoRecipeDTO gelatoRecipeDto)
        {
            if (id != gelatoRecipeDto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var response = await _gelatoRecipeService.UpdateGelatoRecipeAsync(gelatoRecipeDto);

            if (!response.Success)
                return BadRequest($"{response.Message}: {response.HttpResponseCode}");

            return Ok(gelatoRecipeDto);
        }

        // DELETE api/<GelatoRecipesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGelatoRecipe(int id)
        {
            var response = await _gelatoRecipeService.DeleteGelatoRecipeAsync(id);

            if (!response.Success)
                return BadRequest($"{response.Message}: {response.HttpResponseCode}");

            return NoContent();

        }
    }
}
