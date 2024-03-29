﻿using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //[Authorize(Roles = "admin,user.all,user.list")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAllDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[Authorize(Roles = "admin,user.all,user.list")]
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetUserDtoById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[Authorize(Roles = "admin,user.all,user.add")]
        //[HttpPost("add")]
        //public IActionResult Add(User user)
        //{
        //    var result = _userService.Add(user);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        //[Authorize(Roles = "admin,user.all,user.delete")]
        [HttpPost("delete")]
        public IActionResult Delete([FromForm] int id)
        {
            var result = _userService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[Authorize(Roles = "admin,user.all,user.update")]
        [HttpPost("update")]
        public IActionResult Update(UserDto user)
        {
            var result = _userService.UpdateByDto(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
