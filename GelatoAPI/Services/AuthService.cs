using GelatoAPI.Data;
using GelatoAPI.DTOs;
using GelatoAPI.Interfaces;
using GelatoAPI.Services.Communications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GelatoAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthService(IUserService userService , ITokenService tokenService) 
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        public async Task<UserResponse> Login(UserLoginDTO userLoginDto)
        {
            // search user by username
            var user = await _userService.GetByUsernameAsync(userLoginDto.UserName);

            if (user == null)
                return new UserResponse(false, 401, "Unauthorized. Invalid username.", null);

            // hash entered password
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLoginDto.Password));

            // check if pass matches 
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return new UserResponse(false, 401, "Unauthorized. Invalid password.", null);
            }

            // user and pass checked, generate token
            UserDTO userDto = new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                IsAdmin = user.IsAdmin,
                Token = _tokenService.CreateToken(user)
            };

            return new UserResponse(userDto);
        }
    }
}
