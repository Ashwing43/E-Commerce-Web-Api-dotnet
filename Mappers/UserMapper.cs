using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceWebApi.Models;
using ECommerceWebApi.Dtos;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using ECommerceWebApi.Dtos.User;

namespace ECommerceWebApi.Mappers
{
    public static class UserMapper
    {
        public static GetUserDto ToGetUserDto(this User user)
        {
            if (user is Customer cc)
            {
                return new GetUserCustomerDto
                {
                    Id = cc.Id,
                    Name = cc.Name,
                    Email = cc.Email,
                    Addresses = cc.Addresses,
                    UserRole = UserRole.Customer
                };
            }
            else
            {
                return new GetUserAdminDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    UserRole = UserRole.Admin
                };
            }
        }

        public static User ToUser(this CreateUserDto user)
        {
            return (user.Role == UserRole.Customer) ? new Customer()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            } : new Admin()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };
        }
    }
}
