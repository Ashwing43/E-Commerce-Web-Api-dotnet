using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceWebApi.Dtos;
using ECommerceWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Repositories
{
    public interface IUserRepository
    {
        Task<GetUserDto> AddUserAsync(User userModel);
        Task<User> GetUserByIdAsync(Guid id);
        Task<List<User>> GetAllUsersAsync();
        Task SaveChangesAsync();
        void Delete(User userModel);
    }
}
