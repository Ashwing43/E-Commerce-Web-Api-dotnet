using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using ECommerceWebApi.Dtos.Product;
using ECommerceWebApi.Mappers;
using ECommerceWebApi.Models;
using ECommerceWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Controllers
{
    [Route("ecommerce/product")]
    [Controller]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            var productDtos = products.Select(x => x.ToGetProductDto());
            if(products == null){
                return NotFound();
            }
            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if(product == null){
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductDto createProductDto)
        {
            var product = await _productService.AddProductAsync(createProductDto);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CreateProductDto createProductDto){
            Product product = await _productService.GetProductByIdAsync(id);
            if(product == null){
                return NotFound();
            }
            product.Name = createProductDto.Name;
            product.Price = createProductDto.Price;
            product.Quantity = createProductDto.Quantity;
            product.Description = createProductDto.Description;
            await _productService.SaveChangesAsync();
            return Ok(product.ToGetProductDto());
        }

        [HttpDelete("{id}")]
        public  async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            Product product = await _productService.GetProductByIdAsync(id);
            if(product == null){
                return NotFound();
            }
            _productService.DeleteProduct(product);
            return NoContent();
        }
    }
}