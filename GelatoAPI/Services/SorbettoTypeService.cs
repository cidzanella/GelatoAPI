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
    public class SorbettoTypeService : ISorbettoTypeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SorbettoTypeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SorbettoTypeDTO>> ReadSorbettoTypesAsync()
        {
            IEnumerable<SorbettoType> sorbettos = await _context.SorbettoTypes.OrderBy(s => s.Name).ToListAsync();
            IEnumerable<SorbettoTypeDTO> sorbettosDto = _mapper.Map<IEnumerable<SorbettoTypeDTO>>(sorbettos);
            return sorbettosDto;
        }

        public async Task<SorbettoTypeResponse> ReadSorbettoTypeAsync(int id)
        {
            var sorbetto = await _context.SorbettoTypes.FirstOrDefaultAsync(s => s.Id == id);

            if (sorbetto == null)
                return new SorbettoTypeResponse("Sorbetto type not found!");

            var sorbettoDto = _mapper.Map<SorbettoTypeDTO>(sorbetto);
            return new SorbettoTypeResponse(sorbettoDto);

        }

        public async Task<SorbettoTypeResponse> CreateSorbettoTypeAsync(SorbettoTypeCreateDTO sorbettoTypeCreateDto)
        {
            try
            {
                if (await SorbettoTypeExists (sorbettoTypeCreateDto.Name))
                    return new SorbettoTypeResponse("Duplicated sorbetto type name. This sorbetto type already exist on database.");

                var sorbettoType = _mapper.Map<SorbettoType>(sorbettoTypeCreateDto);
                _context.SorbettoTypes.Add(sorbettoType);
                await _context.SaveChangesAsync();

                var sorbettoTypeDto = _mapper.Map<SorbettoTypeDTO>(sorbettoType);

                return new SorbettoTypeResponse(sorbettoTypeDto);

            }
            catch (Exception e)
            {
                return new SorbettoTypeResponse($"An error occurred when saving the sorbetto type: {e.Message} - {e.InnerException}");
            }
        }

        public async Task<SorbettoTypeResponse> UpdateSorbettoTypeAsync(int id, SorbettoTypeDTO sorbettoTypeDto)
        {
            
            if (sorbettoTypeDto == null)
                return new SorbettoTypeResponse("Ocorreu um erro ao tentar localizar o item na base de dados.");

            var sorbettoType = await _context.SorbettoTypes.FindAsync(sorbettoTypeDto.Id);
            
            if (sorbettoType == null)
                return new SorbettoTypeResponse("Ocorreu um erro ao tentar localizar o item na base de dados.");

            try
            {
                _mapper.Map(sorbettoTypeDto, sorbettoType);
                await _context.SaveChangesAsync();
                return new SorbettoTypeResponse(sorbettoTypeDto);

            }
            catch (Exception e)
            {
                return new SorbettoTypeResponse($"An error occurred when saving the sorbetto type update: {e.Message} - {e.InnerException}");
            }

        }

        public async Task<SorbettoTypeResponse> DeleteSorbettoTypeAsync(int id)
        {
            var sorbettoType = await _context.SorbettoTypes.FindAsync(id);

            if (sorbettoType == null)
                return new SorbettoTypeResponse(false, 404, "Sorbetto type not found.", null);

            try
            {
                _context.SorbettoTypes.Remove(sorbettoType);
                await _context.SaveChangesAsync();
                return new SorbettoTypeResponse(true, 204, "No Content", null);
            }
            catch (Exception e)
            {
                return new SorbettoTypeResponse($"An error occurred when deleting the sorbetto type: {e.Message} - {e.InnerException}");
            }
        }

        private async Task<bool> SorbettoTypeExists(string name)
        {
            return await _context.SorbettoTypes.AnyAsync(s => s.Name.ToLower() == name.ToLower());
        }
    }
}
