using GelatoAPI.Data;
using GelatoAPI.DTOs;
using GelatoAPI.Interfaces;
using GelatoAPI.Models;
using GelatoAPI.Services.Communications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GelatoAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        /// GET ALL USERS 
        public async Task<IEnumerable<UserDTO>> ReadUsersAsync()
        {
            List<AppUser> users = await _context.Users.ToListAsync();
            List<UserDTO> usersDto = new();
            
            foreach (AppUser user in users)
            {
                UserDTO userDto = new UserDTO
                {
                    Id = user.Id,
                    IsAdmin = user.IsAdmin,
                    UserName = user.UserName
                };
                usersDto.Add(userDto);                 
            }

            return usersDto; 
        }

        /// GET ONE USER BY ID
        public async Task<UserResponse> ReadUserAsync(int id)
        {
            AppUser user = await _context.Users.FindAsync(id);

            if (user == null)
                return new UserResponse("User not found!");

            UserDTO userDto = new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                IsAdmin = user.IsAdmin
            };

            return new UserResponse(userDto);
        }

        public async Task<UserResponse> CreateUserAsync(UserRegisterDTO userRegisterDto)
        {
            try
            {
                // check if username is not taken
                if (await UserExists(userRegisterDto.UserName))
                    return new UserResponse("Username not available. Try a different one." );

                // hash password
                using var hmac = new HMACSHA512();

                AppUser user = new AppUser
                {
                    UserName = userRegisterDto.UserName.ToLower(),
                    IsAdmin = userRegisterDto.IsAdmin,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDto.Password)),
                    PasswordSalt = hmac.Key
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                UserDTO userDto = new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    IsAdmin = user.IsAdmin
                };
                return new UserResponse(userDto);

            } catch (Exception e)
            {
                return new UserResponse($"An error occurred when saving the user: {e.Message} - {e.InnerException}");
            }

        }

        public async Task<UserResponse> UpdateUserAsync(UserUpdateDTO userDto)
        {

            AppUser user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userDto.Id);

            if (user == null)
                return new UserResponse(false, 404, "Not found!", null);

            // update fields
            user.IsAdmin = userDto.IsAdmin;

            try
            {
                // save changes
                await _context.SaveChangesAsync();
                return new UserResponse(new UserDTO { Id = user.Id, IsAdmin = user.IsAdmin, UserName = user.UserName });
            }
            catch (DbUpdateConcurrencyException)
            {
               return new UserResponse("An DbUpdateConcurrencyException occurred when updating the user.");
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred when updating the user: {e.Message} - {e.InnerException}");
            }

        }

        public async Task<UserResponse> DeleteUserAsync(int id)
        {
            try
            {
                AppUser appUser = await _context.Users.FindAsync(id);
                if (appUser == null)
                    return new UserResponse(false, 404, "User not found.", null);

                _context.Users.Remove(appUser);
                await _context.SaveChangesAsync();

                return new UserResponse(true, 204, "No Content.", null);
            } catch (Exception e)
            {
                return new UserResponse($"An error occurred when deleting the user: {e.Message} - {e.InnerException}");
            }

        }

        public async Task<AppUser> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username.ToLower());
        }

        // checks username to avoid duplicates
        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(u => u.UserName == username.ToLower());
        }

        // checks user ID exists
        private async Task<bool> UserExists(int id)
        {
            return await _context.Users.AnyAsync(u => u.Id == id);
        }

    }
}
