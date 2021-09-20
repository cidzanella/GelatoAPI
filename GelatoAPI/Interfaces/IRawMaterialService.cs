using GelatoAPI.DTOs;
using GelatoAPI.Models;
using GelatoAPI.Services.Communications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GelatoAPI.Interfaces
{
    public interface IRawMaterialService
    {
        Task<IEnumerable<RawMaterialDTO>> ReadRawMaterialsAsync();

        Task<RawMaterialResponse> ReadRawMaterialAsync(int id);
        
        Task<RawMaterialResponse> CreateRawMaterialAsync(RawMaterialDTO rawMaterialDto);
        
        Task<RawMaterialResponse> UpdateRawMaterialAsync(RawMaterialDTO rawMaterialDto);
        
        Task<RawMaterialResponse> DeleteRawMaterialAsync(int id);

        Task<IEnumerable<RawMaterialSupplier>> ReadRawMaterialSuppliersAsync();

        Task<IEnumerable<RawMaterialType>> ReadRawMaterialTypesAsync();

    }
}
