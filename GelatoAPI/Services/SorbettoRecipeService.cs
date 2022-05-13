using AutoMapper;
using GelatoAPI.Data;
using GelatoAPI.DTOs;
using GelatoAPI.Interfaces;
using GelatoAPI.Models;
using GelatoAPI.Services.Communications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.Services
{
    public class SorbettoRecipeService : ISorbettoRecipeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SorbettoRecipeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SorbettoRecipeDTO>> ReadSorbettoRecipesAsync()
        {
            IEnumerable<SorbettoRecipe> recipes = await _context.SorbettoRecipes.Include(r => r.RawMaterial)
                                                    .OrderBy(r => r.RawMaterial.Name)
                                                    .ToListAsync();

            IEnumerable<SorbettoRecipeDTO> recipesDto = _mapper.Map<IEnumerable<SorbettoRecipeDTO>>(recipes);

            return recipesDto;
        }
        
        // search db for all itens (rawMaterials) on the recipe of one specific sorbetto flavour
        public async Task<IEnumerable<SorbettoRecipeDTO>> ReadSorbettoRecipeBySorbettoTypeAsync(int sorbettoTypeId)
        {
            // get sorbetto Recipe Items
            IEnumerable<SorbettoRecipe> recipes = await _context.SorbettoRecipes
                                                                    .Include(s => s.RawMaterial)
                                                                    .Where(s => s.SorbettoTypeId == sorbettoTypeId)
                                                                    .OrderBy(s => s.RawMaterial.Name)
                                                                    .ToListAsync();
            IEnumerable<SorbettoRecipeDTO> recipesDto = _mapper.Map<IEnumerable<SorbettoRecipeDTO>>(recipes);

            return recipesDto;

        }

        public async Task<SorbettoRecipeResponse> ReadSorbettoRecipeItemAsync(int id)
        {
            var sorbettoRecipeItem = await _context.SorbettoRecipes
                                                .Include(s => s.RawMaterial)
                                                .FirstOrDefaultAsync(s => s.Id == id);
            if (sorbettoRecipeItem == null)
                return new SorbettoRecipeResponse("Sorbetto recipe item not found!");

            var sorbettoRecipeItemDto = _mapper.Map<SorbettoRecipeDTO>(sorbettoRecipeItem);

            return new SorbettoRecipeResponse(sorbettoRecipeItemDto);
        }


        public async Task<SorbettoRecipeResponse> CreateBaseRecipeItemAsync(SorbettoRecipeCreateDTO sorbettoRecipeItemCreateDto)
        {
            try
            {
                //check if there is already that rawMaterial on the recipe
                var rawMaterialOnRecipe = await _context.SorbettoRecipes.FirstOrDefaultAsync(r => r.SorbettoTypeId == sorbettoRecipeItemCreateDto.SorbettoTypeId && r.RawMaterialId == sorbettoRecipeItemCreateDto.RawMaterialId);

                if (rawMaterialOnRecipe != null)
                    return new SorbettoRecipeResponse("Não é possível incluir novamente um ingrediente já adicionado a receita.");

                var sorbettoRecipeItem = _mapper.Map<SorbettoRecipe>(sorbettoRecipeItemCreateDto);

                _context.SorbettoRecipes.Add(sorbettoRecipeItem);
                await _context.SaveChangesAsync();

                var sorbettoRecipeItemCreated = await _context.SorbettoRecipes.Include(m => m.RawMaterial).FirstOrDefaultAsync(i => i.Id == sorbettoRecipeItem.Id);
                var sorbettoRecipeItemCreatedDto = _mapper.Map<SorbettoRecipeDTO>(sorbettoRecipeItemCreated);

                return new SorbettoRecipeResponse(sorbettoRecipeItemCreatedDto);
            }
            catch (Exception e)
            {
                return new SorbettoRecipeResponse($"An error occurred when saving the sorbetto recipe: {e.Message} - {e.InnerException}");
            }
        }

        public async Task<SorbettoRecipeResponse> UpdateBaseRecipeItemAsync(SorbettoRecipeDTO sorbettoRecipeItemDto)
        {
            var sorbettoRecipeItem = await _context.SorbettoRecipes.FindAsync(sorbettoRecipeItemDto.Id);

            if (sorbettoRecipeItem == null)
                return new SorbettoRecipeResponse("Ocorreu um erro ao tentar localizar o item na base de dados.");
            
            try
            {
                // update fields
                _mapper.Map(sorbettoRecipeItemDto, sorbettoRecipeItem);
                // save changes
                await _context.SaveChangesAsync();
                return new SorbettoRecipeResponse(sorbettoRecipeItemDto);
            }
            catch (Exception e)
            {
                return new SorbettoRecipeResponse($"An error occurred when saving the sorbetto recipe update: {e.Message} - {e.InnerException}");
            }
        }

        public async Task<SorbettoRecipeResponse> DeleteBaseRecipeItemAsync(int id)
        {
            var sorbettoRecipeItem = await _context.SorbettoRecipes.FindAsync(id);

            if (sorbettoRecipeItem == null)
                return new SorbettoRecipeResponse(false, 404, "Sorbetto recipe item not found.", null);

            try
            {
                _context.SorbettoRecipes.Remove(sorbettoRecipeItem);
                await _context.SaveChangesAsync();
                return new SorbettoRecipeResponse(true, 204, "No Content.", null);

            }
            catch (Exception e)
            {
                return new SorbettoRecipeResponse($"An error occurred when deleting the sorbetto recipe item: {e.Message} - {e.InnerException}");
            }
        }

        // delete all the itens of a sorbetto recipe specified by sorbetto type id
        public async Task<SorbettoRecipeResponse> DeleteBaseRecipeBySorbettoTypeAsync(int id)
        {

            var sorbettoRecipeItens = await _context.SorbettoRecipes
                                                    .Where(s => s.SorbettoTypeId == id)
                                                    .ToListAsync();
            if (sorbettoRecipeItens == null)
                return new SorbettoRecipeResponse(false, 404, "Sorbetto recipe not found for this sorbetto type.", null);

            try
            {
                foreach(var item in sorbettoRecipeItens)
                {
                    _context.SorbettoRecipes.Remove(item);
                }
                await _context.SaveChangesAsync();
                return new SorbettoRecipeResponse(true, 204, "No Content.", null);

            }
            catch (Exception e)
            {
                return new SorbettoRecipeResponse($"An error occurred when deleting the sorbetto recipe itens: {e.Message} - {e.InnerException}");
            }
        }
    }
}
