using ECommerceWebApi.Dtos;
using ECommerceWebApi.Mappers;
using ECommerceWebApi.Models;
using ECommerceWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace ECommerceWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserDto> AddAsync(CreateUserDto userDto)
        {
            User userModel = (userDto.Role == UserRole.Admin) ? (Admin)userDto.ToUser() : (Customer)userDto.ToUser();
            GetUserDto getUserDto = await _userRepository.AddUserAsync(userModel);
            await _userRepository.SaveChangesAsync();
            return getUserDto;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            User user = await _userRepository.GetUserByIdAsync(id);
            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async void DisplayInfo(Guid id)
        {
            User user = await _userRepository.GetUserByIdAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _userRepository.SaveChangesAsync();
        }

        public void Delete(User userModel)
        {
            _userRepository.Delete(userModel);
        }
    }
}
