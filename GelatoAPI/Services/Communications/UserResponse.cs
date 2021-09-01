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

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="user">Saved category.</param>
        /// <returns>Response.</returns>
        public UserResponse(UserDTO userDto) : this(true, 200, string.Empty, userDto)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public UserResponse(string message) : this(false, 404, message, null)
        { }
    }
}
