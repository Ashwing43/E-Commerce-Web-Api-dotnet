using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceWebApi.Dtos.Product;
using ECommerceWebApi.Models;
using ECommerceWebApi.QueryObjects;

namespace ECommerceWebApi.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync(QueryObject queryObject);
        Task<Product> GetProductByIdAsync(Guid id);
        Task<GetProductDto> AddProductAsync(Product product);
        void DeleteProduct(Product product);
        Task SaveChangesAsync();
    }
}