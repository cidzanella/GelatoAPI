using GelatoAPI.DTOs;
using GelatoAPI.Services.Communications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GelatoAPI.Interfaces
{
    public interface ISorbettoTypeService
    {
        Task<IEnumerable<SorbettoTypeDTO>> ReadSorbettoTypesAsync();

        Task<SorbettoTypeResponse> ReadSorbettoTypeAsync(int id);

        Task<SorbettoTypeResponse> CreateSorbettoTypeAsync(SorbettoTypeCreateDTO sorbettoTypeDto);

        Task<SorbettoTypeResponse> UpdateSorbettoTypeAsync(int id, SorbettoTypeDTO sorbettoTypeDto);

        Task<SorbettoTypeResponse> DeleteSorbettoTypeAsync(int id);

    }
}
