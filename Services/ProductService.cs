using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using ECommerceWebApi.Data;
using ECommerceWebApi.Dtos.Product;
using ECommerceWebApi.Mappers;
using ECommerceWebApi.Models;
using ECommerceWebApi.QueryObjects;
using ECommerceWebApi.Repositories;

namespace ECommerceWebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProductsAsync(QueryObject queryObject)
        {
            var products = await _productRepository.GetAllProductsAsync(queryObject);
            return products;
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }
        public async Task<GetProductDto> AddProductAsync(CreateProductDto createProductDto)
        {
            Product product = createProductDto.ToProduct();
            var getProductDto = await _productRepository.AddProductAsync(product);
            return getProductDto;
        }

        public void DeleteProduct(Product product)
        {
            _productRepository.DeleteProduct(product);
        }


        public async Task SaveChangesAsync()
        {
            await _productRepository.SaveChangesAsync();
        }
    }
}