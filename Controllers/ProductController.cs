using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using ECommerceWebApi.Dtos.Product;
using ECommerceWebApi.Mappers;
using ECommerceWebApi.Models;
using ECommerceWebApi.QueryObjects;
using ECommerceWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public async Task<IActionResult> GetAll([FromQuery] QueryObject queryObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = await _productService.GetAllProductsAsync(queryObject);
            var productDtos = products.Select(x => x.ToGetProductDto());
            if (products == null)
            {
                return NotFound();
            }
            return Ok(productDtos);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productService.AddProductAsync(createProductDto);
            return Ok(product);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = updateProductDto.Name;
            product.Price = updateProductDto.Price;
            product.Quantity = updateProductDto.Quantity;
            product.Description = updateProductDto.Description;
            await _productService.SaveChangesAsync();
            return Ok(product.ToGetProductDto());
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _productService.DeleteProduct(product);
            return NoContent();
        }
    }
}