using GelatoAPI.DTOs;
using GelatoAPI.Models;
using GelatoAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.Interfaces
{
    public interface IGelatoRecipeService
    {

        Task<IEnumerable<GelatoRecipeDTO>> ReadGelatoRecipesAsync();

        Task<GelatoRecipeResponse> ReadGelatoRecipeAsync(int id);

        Task<GelatoRecipeResponse> CreateGelatoRecipeAsync(GelatoRecipeCreateDTO GelatoRecipeDto);

        Task<GelatoRecipeResponse> UpdateGelatoRecipeAsync(GelatoRecipeDTO GelatoRecipeDto);

        Task<GelatoRecipeResponse> DeleteGelatoRecipeAsync(int id);

        Task<IEnumerable<RawMaterial>> ReadPastasAsync();

        Task<IEnumerable<RawMaterial>> ReadVariegatosAsync();

        Task<IEnumerable<BaseType>> ReadBaseTypesAsync();

    }
}
