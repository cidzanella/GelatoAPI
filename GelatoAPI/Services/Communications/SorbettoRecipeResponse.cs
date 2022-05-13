using GelatoAPI.DTOs;

namespace GelatoAPI.Services.Communications
{
    public class SorbettoRecipeResponse : BaseResponse
    {
        public SorbettoRecipeDTO SorbettoRecipeDto { get; private set; }

        public SorbettoRecipeResponse(bool success, int httpResponseCode, string message, SorbettoRecipeDTO sorbettoRecipeDto) : base(success, httpResponseCode, message)
        {
            SorbettoRecipeDto = sorbettoRecipeDto;
        }

        // create a success response
        public SorbettoRecipeResponse(SorbettoRecipeDTO sorbettoRecipeDto) : this(true, 200, string.Empty, sorbettoRecipeDto)
        { }

        // create an error response
        public SorbettoRecipeResponse(string message) : this(false, 404, message, null)
        { }

    }
}
