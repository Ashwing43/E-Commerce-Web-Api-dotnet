using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceWebApi.Dtos;
using ECommerceWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Services
{
    public interface IUserService
    {
        Task<GetUserDto> AddAsync(CreateUserDto userDto);
        Task<User> GetByIdAsync(Guid id);
        Task<List<User>> GetAllUsersAsync();
        void DisplayInfo(Guid id);
        Task SaveChangesAsync();
        void Delete(User userModel);
    }
}
