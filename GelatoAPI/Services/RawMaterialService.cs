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
    public class RawMaterialService : IRawMaterialService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RawMaterialService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RawMaterialDTO>> ReadRawMaterialsAsync()
        {
            IEnumerable<RawMaterial> rawMaterials = await _context.RawMaterials.Include(r => r.Supplier).Include(r => r.Type).OrderBy(r => r.Name).ToListAsync();
            IEnumerable<RawMaterialDTO> rawMaterialsDto = _mapper.Map<IEnumerable<RawMaterialDTO>>(rawMaterials);
            return rawMaterialsDto;
        }


        public async Task<RawMaterialResponse> ReadRawMaterialAsync(int id)
        {

            var rawMaterial = await _context.RawMaterials.Include(r => r.Supplier).Include(r => r.Type).FirstOrDefaultAsync(r => r.Id == id);

            if (rawMaterial == null)
                return new RawMaterialResponse("Raw Material not found!");

            var rawMaterialDto = _mapper.Map<RawMaterialDTO>(rawMaterial);

            return new RawMaterialResponse(rawMaterialDto);
        }

        public async Task<RawMaterialResponse> CreateRawMaterialAsync(RawMaterialDTO rawMaterialDto)
        {
            try
            {
                if (await RawMaterialExists(rawMaterialDto.Name))
                    return new RawMaterialResponse("Duplicated raw material name. This raw material already exist on database.");

                //var rawMaterial = _mapper.Map<RawMaterial>(rawMaterialDto);
                RawMaterial rawMaterial = new RawMaterial
                {
                    Name = rawMaterialDto.Name,
                    SupplierId = rawMaterialDto.SupplierId,
                    TypeId = rawMaterialDto.TypeId,
                    Active = rawMaterialDto.Active
                };

                _context.RawMaterials.Add(rawMaterial);
                await _context.SaveChangesAsync();

                rawMaterialDto = _mapper.Map<RawMaterialDTO>(rawMaterial);

                return new RawMaterialResponse(rawMaterialDto);
            } catch (Exception e)
            {
                return new RawMaterialResponse($"An error occurred when saving the raw material: {e.Message} - {e.InnerException}");
            }
        }

        public async Task<RawMaterialResponse> UpdateRawMaterialAsync(RawMaterialDTO rawMaterialDto)
        {
            RawMaterial rawMaterial = await _context.RawMaterials.FindAsync(rawMaterialDto.Id);

            if (rawMaterial == null)
                return new RawMaterialResponse("Ocorreu um erro ao tentar localizar o item na base de dados.");

            try
            {
                // update fields
                rawMaterial.Name = rawMaterialDto.Name;
                rawMaterial.SupplierId = rawMaterialDto.SupplierId;
                rawMaterial.TypeId = rawMaterialDto.TypeId;
                rawMaterial.Active = rawMaterialDto.Active;

                // save changes
                await _context.SaveChangesAsync();
                rawMaterialDto = _mapper.Map<RawMaterialDTO>(rawMaterial);
                return new RawMaterialResponse(rawMaterialDto);
            }
            catch (Exception e)
            {
                return new RawMaterialResponse($"An error occurred when saving the raw material update: {e.Message} - {e.InnerException}");
            }

        }

        public async Task<RawMaterialResponse> DeleteRawMaterialAsync(int id)
        {

            var rawMaterial = await _context.RawMaterials.FindAsync(id);
            
            if (rawMaterial == null)
                return new RawMaterialResponse(false, 404, "Raw material not found.", null);

            try
            {
                _context.RawMaterials.Remove(rawMaterial);
                await _context.SaveChangesAsync();

                return new RawMaterialResponse(true, 204, "No Content.", null);
            }
            catch (Exception e)
            {
                return new RawMaterialResponse($"An error occurred when deleting the raw material: {e.Message} - {e.InnerException}");
            }
        }

        public async Task<IEnumerable<RawMaterialSupplier>> ReadRawMaterialSuppliersAsync()
        {
            return await _context.RawMaterialSuppliers.ToListAsync();
        }

        public async Task<IEnumerable<RawMaterialType>> ReadRawMaterialTypesAsync()
        {
            return await _context.RawMaterialTypes.ToListAsync();
        }

        // checks RawMaterial Name to avoid duplicates
        private async Task<bool> RawMaterialExists(string name)
        {
            return await _context.RawMaterials.AnyAsync(r => r.Name.ToLower() == name.ToLower());
        }

        // checks RawMaterial ID exists
        private async Task<bool> RawMaterialExists(int id)
        {
            return await _context.RawMaterials.AnyAsync(r => r.Id == id);
        }


    }
}
