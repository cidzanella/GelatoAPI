using GelatoAPI.DTOs;

namespace GelatoAPI.Services.Communications
{
    public class UserResponse : BaseResponse
    {
        public UserDTO UserDto { get; private set; }

        public UserResponse(bool success, int httpResponseCode, string message, UserDTO userDto) : base(success, httpResponseCode, message)
        {
            UserDto = userDto;
        }

        // Creates a success response.
        public UserResponse(UserDTO userDto) : this(true, 200, string.Empty, userDto)
        { }

        // Creates am error response.
        public UserResponse(string message) : this(false, 404, message, null)
        { }
    }
}
