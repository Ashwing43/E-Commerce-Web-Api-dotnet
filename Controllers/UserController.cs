using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceWebApi.Data;
using ECommerceWebApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using ECommerceWebApi.Models;
using ECommerceWebApi.Mappers;
using ECommerceWebApi.Services;

namespace ECommerceWebApi.Controllers
{
    [Route("ecommerce/user")]
    [Controller]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            var userDtos = users.Select(user => user.ToGetUserDto());
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid([FromRoute] Guid id) 
        {
            User user  = await _userService.GetByIdAsync(id);
            if(user == null){
                return NotFound();
            }
            return Ok(user.ToGetUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserDto userDto)
        {
            GetUserDto user = await _userService.AddAsync(userDto);
            return Ok(user);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            var userModel = await _userService.GetByIdAsync(id);
            if(userModel == null)
            {
                return NotFound();
            }
            userModel.Name = updateUserDto.Name;
            userModel.Email = updateUserDto.Email;
            await _userService.SaveChangesAsync();
            return Ok(userModel.ToGetUserDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var userModel = await _userService.GetByIdAsync(id);
            if(userModel == null)
            {
                return NotFound();
            }
            _userService.Delete(userModel);
            await _userService.SaveChangesAsync();
            return NoContent(); 
        }
    }
}