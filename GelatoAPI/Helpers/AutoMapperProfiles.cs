using AutoMapper;
using GelatoAPI.DTOs;
using GelatoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<AppUser, UserDTO>();
            CreateMap<AppUser, UserLoginDTO>();
            CreateMap<AppUser, UserRegisterDTO>();
            CreateMap<AppUser, UserUpdateDTO>();

            CreateMap<RawMaterial, RawMaterialDTO>();
            CreateMap<RawMaterialDTO, RawMaterial>();
        }
    }
}
