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
    public class BaseRecipeService : IBaseRecipeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BaseRecipeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BaseRecipeDTO>> ReadBaseRecipesAsync()
        {
            var baseRecipes = await _context.BaseRecipes.Include(m => m.RawMaterial).OrderBy(r => r.RawMaterial.Name).ToListAsync();
            var baseRecipesDto = _mapper.Map<IEnumerable<BaseRecipeDTO>>(baseRecipes);
            return baseRecipesDto;
        }

        public async Task<BaseRecipeResponse> ReadBaseRecipeAsync(int id)
        {
            var baseRecipe = await _context.BaseRecipes.Include(m => m.RawMaterial).FirstOrDefaultAsync(r => r.Id == id);

            if (baseRecipe == null)
                return new BaseRecipeResponse("Item da receita não encontrado!");

            return new BaseRecipeResponse(_mapper.Map<BaseRecipeDTO>(baseRecipe));
        }

        public async Task<IEnumerable<BaseRecipeDTO>> ReadBaseRecipesByBaseTypeAsync(int baseTypeId)
        {
            var baseRecipes = await _context.BaseRecipes.Include(m => m.RawMaterial).Where(r => r.BaseTypeId == baseTypeId).OrderBy(r => r.RawMaterial.Name).ToListAsync();
            return _mapper.Map<IEnumerable<BaseRecipeDTO>>(baseRecipes);   
        }

        public async Task<BaseRecipeResponse> CreateBaseRecipeAsync(BaseRecipeCreateDTO baseRecipeCreateDto)
        {
            //check if there is already that rawMaterial on the recipe
            var rawMaterialOnRecipe = await _context.BaseRecipes.FirstOrDefaultAsync(r => r.BaseTypeId == baseRecipeCreateDto.BaseTypeId && r.RawMaterialId == baseRecipeCreateDto.RawMaterialId);
         
            if (rawMaterialOnRecipe != null)
                return new BaseRecipeResponse("Não é possível incluir novamente um ingrediente já adicionado a receita.");

            var baseRecipe = _mapper.Map<BaseRecipe>(baseRecipeCreateDto);
             
            _context.BaseRecipes.Add(baseRecipe);
            await _context.SaveChangesAsync();

            var baseRecipeCreated = await _context.BaseRecipes.Include(m => m.RawMaterial).FirstOrDefaultAsync(r => r.Id == baseRecipe.Id);
            return new BaseRecipeResponse(_mapper.Map<BaseRecipeDTO>(baseRecipeCreated));

        }

        public async Task<BaseRecipeResponse> UpdateBaseRecipeAsync(BaseRecipeUpdateDTO baseRecipeUpdateDto)
        {
            var baseRecipe = await _context.BaseRecipes.FindAsync(baseRecipeUpdateDto.Id);

            if (baseRecipe == null)
                return new BaseRecipeResponse("Ocorreu um erro ao tentar localizar o item na base de dados.");

            baseRecipe.GramsPerKg = baseRecipeUpdateDto.GramsPerKg;

            await _context.SaveChangesAsync();

            return new BaseRecipeResponse(_mapper.Map<BaseRecipeDTO>(baseRecipe));
        }

        public async Task<BaseRecipeResponse> DeleteBaseRecipeAsync(int id)
        {
            var baseRecipe = await _context.BaseRecipes.FindAsync(id);

            if (baseRecipe == null)
                return new BaseRecipeResponse(false, 404, "Item não localizado.", null);

            _context.BaseRecipes.Remove(baseRecipe);
            await _context.SaveChangesAsync();

            return new BaseRecipeResponse(true, 204, "No content.", null);

        }


        public async Task<IEnumerable<BaseTypeDTO>> ReadBaseTypesAsync()
        {
            var baseTypes = await _context.BaseTypes.ToListAsync();
            return _mapper.Map<IEnumerable<BaseTypeDTO>>(baseTypes);
        }

    }
}
