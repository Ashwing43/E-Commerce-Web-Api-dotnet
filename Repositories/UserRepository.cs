// using DataStorage;
using ECommerceWebApi.Data;
using ECommerceWebApi.Dtos;
using ECommerceWebApi.Mappers;
using ECommerceWebApi.Models;
using Microsoft.EntityFrameworkCore;



namespace ECommerceWebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public UserRepository(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _dbContext.User.ToListAsync();
            return users;
        }

        public async Task<GetUserDto> AddUserAsync(User userModel)
        {
            await _dbContext.User.AddAsync(userModel);
            await _dbContext.SaveChangesAsync(); //We save the model over here
            return userModel.ToGetUserDto();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            User user = await _dbContext.User.FindAsync(id);
            return user;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public void Delete(User userModel)
        {
            _dbContext.User.Remove(userModel);
        }
    }
}
