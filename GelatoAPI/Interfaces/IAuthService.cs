using GelatoAPI.DTOs;
using GelatoAPI.Services.Communications;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GelatoAPI.Interfaces
{
    // interface with Account services for user register and login
    public interface IAuthService
    {
        Task<UserResponse> Login(UserLoginDTO userLoginDto);

    }
}
