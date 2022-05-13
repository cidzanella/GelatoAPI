using GelatoAPI.DTOs;

namespace GelatoAPI.Services.Communications
{
    public class SorbettoTypeResponse : BaseResponse
    {
        public SorbettoTypeDTO SorbettoTypeDto { get; private set; }
        public SorbettoTypeResponse(bool success, int httpResponseCode, string message, SorbettoTypeDTO sorbettoTypeDto) : base(success, httpResponseCode, message)
        {
            SorbettoTypeDto = sorbettoTypeDto;
        }
        
        // create a success response
        public SorbettoTypeResponse(SorbettoTypeDTO sorbettoTypeDto) : this(true, 200, string.Empty, sorbettoTypeDto)
        {
                
        }

        // create an error response
        public SorbettoTypeResponse(string message) : this(false, 404, message, null)
        {
                
        }
       
    }
}
