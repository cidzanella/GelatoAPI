using GelatoAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.Services.Communications
{
    public class RawMaterialResponse : BaseResponse
    {
        public RawMaterialDTO RawMaterialDto { get; private set; }

        public RawMaterialResponse(bool success, int httpResponseCode, string message, RawMaterialDTO rawMaterialDto) : base(success, httpResponseCode, message)
        {
            RawMaterialDto = rawMaterialDto;
        }

        // create a success response
        public RawMaterialResponse(RawMaterialDTO rawMaterialDto) : this(true, 200, string.Empty, rawMaterialDto)
        { }
        
        // create am error response
        public RawMaterialResponse(string message) : this(false, 404, message, null) 
        { }
    }
}
