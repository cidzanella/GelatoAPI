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

            CreateMap<GelatoRecipe, GelatoRecipeDTO>();
            CreateMap<GelatoRecipeDTO, GelatoRecipe>();
            CreateMap<GelatoRecipeCreateDTO, GelatoRecipe>();

            CreateMap<RawMaterial, RawMaterialDTO>();
            CreateMap<RawMaterialDTO, RawMaterial>();

            CreateMap<BaseRecipe, BaseRecipeDTO>();
            CreateMap<BaseRecipeDTO, BaseRecipe>();
            CreateMap<BaseRecipeCreateDTO, BaseRecipe>();

            CreateMap<BaseType, BaseTypeDTO>();
            CreateMap<BaseTypeDTO, BaseType>();

            CreateMap<SorbettoType, SorbettoTypeDTO>();
            CreateMap<SorbettoTypeDTO, SorbettoType>();
            CreateMap<SorbettoTypeCreateDTO, SorbettoType>();

            CreateMap<SorbettoRecipe, SorbettoRecipeDTO>();
            CreateMap<SorbettoRecipeDTO, SorbettoRecipe>();
            CreateMap<SorbettoRecipeCreateDTO, SorbettoRecipe>();

        }
    }
}
