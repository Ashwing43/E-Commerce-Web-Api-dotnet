using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceWebApi.Dtos.Product;
using ECommerceWebApi.Models;

namespace ECommerceWebApi.Mappers
{
    public static  class ProductMapper
    {
        public static Product ToProduct(this CreateProductDto createProductDto){
            return new Product{
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                Quantity = createProductDto.Quantity,
                Description = createProductDto.Description,
            };
        }

        public static GetProductDto ToGetProductDto(this Product product){
            return new GetProductDto(){
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                Description = product.Description
            };
        }
    }
}