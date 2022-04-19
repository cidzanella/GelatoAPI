using GelatoAPI.DTOs;
using GelatoAPI.Models;
using GelatoAPI.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.Interfaces
{
    public interface IBaseRecipeService
    {
        Task<IEnumerable<BaseRecipeDTO>> ReadBaseRecipesAsync();
        
        // return all the ingredients of an specific base 
        Task<IEnumerable<BaseRecipeDTO>> ReadBaseRecipesByBaseTypeAsync(int baseTypeId);

        Task<BaseRecipeResponse> ReadBaseRecipeAsync(int id);

        Task<BaseRecipeResponse> CreateBaseRecipeAsync(BaseRecipeCreateDTO baseRecipeDto);

        Task<BaseRecipeResponse> UpdateBaseRecipeAsync(BaseRecipeUpdateDTO baseRecipeDto);

        Task<BaseRecipeResponse> DeleteBaseRecipeAsync(int id);

        Task<IEnumerable<BaseTypeDTO>> ReadBaseTypesAsync();

    }
}
