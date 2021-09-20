using GelatoAPI.DTOs;
using GelatoAPI.Models;
using GelatoAPI.Services.Communications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GelatoAPI.Interfaces
{
    // interface with CRUD methods for AppUser
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> ReadUsersAsync();

        Task<UserResponse> ReadUserAsync(int id);

        Task<UserResponse> CreateUserAsync(UserRegisterDTO userRegisterDto);

        Task<UserResponse> UpdateUserAsync(UserUpdateDTO user);

        Task<UserResponse> DeleteUserAsync(int id);

        Task<AppUser> GetByUsernameAsync(string username);

    }
}
