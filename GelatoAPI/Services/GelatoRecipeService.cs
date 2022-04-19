using AutoMapper;
using GelatoAPI.Data;
using GelatoAPI.DTOs;
using GelatoAPI.Interfaces;
using GelatoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.Services
{
    public class GelatoRecipeService : IGelatoRecipeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GelatoRecipeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GelatoRecipeDTO>> ReadGelatoRecipesAsync()
        {
            IEnumerable<GelatoRecipe> gelatos = await _context.GelatoRecipes
                                                .Include(g => g.BaseType)
                                                .Include(g => g.PastaA)
                                                .Include(g => g.PastaB)
                                                .Include(g => g.VariegatoA)
                                                .Include(g => g.VariegatoB)
                                                .OrderBy(g => g.Name).ToListAsync();
            IEnumerable<GelatoRecipeDTO> gelatosDto = _mapper.Map<IEnumerable<GelatoRecipeDTO>>(gelatos);
            return gelatosDto;
        }

        public async Task<GelatoRecipeResponse> ReadGelatoRecipeAsync(int id)
        {
            var gelatoRecipe = await _context.GelatoRecipes
                                                .Include(g => g.BaseType)
                                                .Include(g => g.PastaA)
                                                .Include(g => g.PastaB)
                                                .Include(g => g.VariegatoA)
                                                .Include(g => g.VariegatoB)
                                                .FirstOrDefaultAsync(g => g.Id == id);
            if (gelatoRecipe == null)
                return new GelatoRecipeResponse("Gelato recipe not found!");

            var gelatoRecipeDto = _mapper.Map<GelatoRecipeDTO>(gelatoRecipe);

            return new GelatoRecipeResponse(gelatoRecipeDto);
        }

        public async Task<GelatoRecipeResponse> CreateGelatoRecipeAsync(GelatoRecipeCreateDTO gelatoRecipeCreateDto)
        {
            try
            {
                if (await GelatoRecipeExists(gelatoRecipeCreateDto.Name))
                    return new GelatoRecipeResponse("Duplicated gelato name. This gelato recipe already exist on database.");

                var gelatoRecipe = _mapper.Map<GelatoRecipe>(gelatoRecipeCreateDto);

                // tentativa de usar mapper acima para evitar a listagem abaixo
                //var gelatoRecipe = new GelatoRecipe
                //{
                //    Name = gelatoRecipeDto.Name,
                //    Active = gelatoRecipeDto.Active
                //};

                _context.GelatoRecipes.Add(gelatoRecipe);
                await _context.SaveChangesAsync();

                var gelatoRecipeDto = _mapper.Map<GelatoRecipeDTO>(gelatoRecipe);

                return new GelatoRecipeResponse(gelatoRecipeDto);
            }
            catch (Exception e)
            {
                return new GelatoRecipeResponse($"An error occurred when saving the gelato recipe: {e.Message} - {e.InnerException}");
            }
        }

        public async Task<GelatoRecipeResponse> UpdateGelatoRecipeAsync(GelatoRecipeDTO gelatoRecipeDto)
        {
            var gelatoRecipe = await _context.GelatoRecipes.FindAsync(gelatoRecipeDto.Id);

            if (gelatoRecipe == null)
                return new GelatoRecipeResponse("Ocorreu um erro ao tentar localizar o item na base de dados.");

            try
            {
                // update fields
                _mapper.Map(gelatoRecipeDto, gelatoRecipe);
                // save changes
                await _context.SaveChangesAsync();
                return new GelatoRecipeResponse(gelatoRecipeDto);
            }
            catch (Exception e)
            {
                return new GelatoRecipeResponse($"An error occurred when saving the gelato recipe update: {e.Message} - {e.InnerException}");
            }

        }

        public async Task<GelatoRecipeResponse> DeleteGelatoRecipeAsync(int id)
        {
            var gelatoRecipe = await _context.GelatoRecipes.FindAsync(id);

            if (gelatoRecipe == null)
                return new GelatoRecipeResponse(false, 404, "Gelato recipe not found.", null);

            try
            {
                _context.GelatoRecipes.Remove(gelatoRecipe);
                await _context.SaveChangesAsync();
                return new GelatoRecipeResponse(true, 204, "No Content.", null);
            }
            catch (Exception e)
            {
                return new GelatoRecipeResponse($"An error occurred when deleting the gelato recipe: {e.Message} - {e.InnerException}");
            }
        }

        public  Task<IEnumerable<RawMaterial>> ReadPastasAsync()
        {
             return null;
        }

        public  Task<IEnumerable<RawMaterial>> ReadVariegatosAsync()
        {
            return null;
        }

        public Task<IEnumerable<BaseType>> ReadBaseTypesAsync()
        {
            throw new NotImplementedException();
        }

        // checks Name to avoid duplicates
        private async Task<bool> GelatoRecipeExists(string name)
        {
            return await _context.GelatoRecipes.AnyAsync(r => r.Name.ToLower() == name.ToLower());
        }


    }
}
