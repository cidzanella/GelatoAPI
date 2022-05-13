using GelatoAPI.DTOs;
using GelatoAPI.Services.Communications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GelatoAPI.Interfaces
{
    public interface ISorbettoRecipeService
    {
        //return all the recipes itens of all the sorbetto on the database
        Task<IEnumerable<SorbettoRecipeDTO>> ReadSorbettoRecipesAsync();

        //return all the recipes itens of a specific sorbetto 
        Task<IEnumerable<SorbettoRecipeDTO>> ReadSorbettoRecipeBySorbettoTypeAsync(int sorbettoTypeId);

        Task<SorbettoRecipeResponse> ReadSorbettoRecipeItemAsync(int id);

        Task<SorbettoRecipeResponse> CreateBaseRecipeItemAsync(SorbettoRecipeCreateDTO sorbettoRecipeItemCreateDto);

        Task<SorbettoRecipeResponse> UpdateBaseRecipeItemAsync(SorbettoRecipeDTO sorbettoRecipeItemDto);

        Task<SorbettoRecipeResponse> DeleteBaseRecipeItemAsync(int id);

        Task<SorbettoRecipeResponse> DeleteBaseRecipeBySorbettoTypeAsync(int id);

    }
}
