using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ECommerceWebApi.Data;
using ECommerceWebApi.Dtos.Product;
using ECommerceWebApi.Mappers;
using ECommerceWebApi.Models;
using ECommerceWebApi.QueryObjects;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ECommerceWebApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ProductRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<List<Product>> GetAllProductsAsync(QueryObject queryObject)
        {
            var products = _dbContext.Products.AsQueryable();
            if (queryObject.MaxPrice > 0 && queryObject.MinPrice > 0)
            {
                products = products.Where(p => p.Price >= queryObject.MinPrice && p.Price <= queryObject.MaxPrice);
            }
            else if (queryObject.MinPrice > 0)
            {
                products = products.Where(p => p.Price >= queryObject.MinPrice);
            }
            else if (queryObject.MaxPrice > 0)
            {
                products = products.Where(p => p.Price <= queryObject.MaxPrice);
            }
            if (queryObject.Quantity > 0)
            {
                products = products.Where(p => p.Quantity >= queryObject.Quantity);
            }
            return await products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            return product;
        }
        public async Task<GetProductDto> AddProductAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product.ToGetProductDto();
        }

        public void DeleteProduct(Product product)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}