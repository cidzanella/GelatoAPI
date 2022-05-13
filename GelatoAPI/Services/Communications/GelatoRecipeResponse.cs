using GelatoAPI.DTOs;
using GelatoAPI.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.Services.Communications
{
    public class GelatoRecipeResponse : BaseResponse
    {
        public GelatoRecipeDTO GelatoRecipeDto { get; private set; }
     
        public GelatoRecipeResponse(bool success, int httpResponseCode, string message, GelatoRecipeDTO gelatoRecipeDto) : base(success, httpResponseCode, message)
        {
            GelatoRecipeDto = gelatoRecipeDto;
        }

        // create a success response
        public GelatoRecipeResponse(GelatoRecipeDTO gelatoRecipeDto) : this(true, 200, string.Empty, gelatoRecipeDto)
        { }

        // create an error response
        public GelatoRecipeResponse(string message) : this(false, 404, message, null)
        { }
    }

}
