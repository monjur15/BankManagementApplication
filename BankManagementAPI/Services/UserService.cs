using BankManagementAPI.Data;
using BankManagementAPI.DTOs;
using BankManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BankManagementAPI.Services
{
    public interface IUserService
    {
        Task<UserDto> RegisterUserAsync(UserDto userDto);
        Task<UserDto2> GetUserByIdAsync(int id);
        Task<AuthenticatedUserDto> AuthenticateAsync(string email, string password);
    }
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<AuthenticatedUserDto> AuthenticateAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            return new AuthenticatedUserDto
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role
            };
        }

        public async Task<UserDto> RegisterUserAsync(UserDto userDto)
        {
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                Role = userDto.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return userDto;
        }

        public async Task<UserDto2> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user == null ? null : new UserDto2
            {
                FullName = user.FirstName + " " + user.LastName,
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}
