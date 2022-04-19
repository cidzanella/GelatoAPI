using GelatoAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.Services.Communications
{
    public class BaseRecipeResponse : BaseResponse
    {
        public BaseRecipeDTO BaseRecipeDto { get; private set; }
     
        public BaseRecipeResponse(bool success, int httpResponseCode, string message, BaseRecipeDTO baseRecipeDto) : base(success, httpResponseCode, message)
        {
            BaseRecipeDto = baseRecipeDto;
        }

        public BaseRecipeResponse(BaseRecipeDTO baseRecipeDto) : this(true, 200, string.Empty, baseRecipeDto)
        { }

        public BaseRecipeResponse(string message) : this(false, 404, message, null)
        { }
    }
}
