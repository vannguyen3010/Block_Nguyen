using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Data;
using MyBlog.Dto.User;
using MyBlog.Models;
using MyBlog.Repository;


namespace MyBlog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {


            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult AddUser(CreateUserDto createUserDto)
        {
            if (ModelState.IsValid)
            {
                var user = (new Models.User()
                {
                    DisplayName = createUserDto.DisplayName,
                    Email = createUserDto.Email,
                    Phone = createUserDto.Phone,
                    Address = createUserDto.Address,
                    DateOfBirth = createUserDto.DateOfBirth
                });
                var createdUser = _userRepository.InsertUser(user);
                return Ok(createdUser);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListUser()
        {

            var listUser = await _userRepository.GetListUser();

            return Ok(listUser);

        }


        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromQuery] Guid id)
        {
            return Ok(await _userRepository.DeleteUser(id));
        }

        [HttpPut]
        public async Task<IActionResult> PutUser([FromQuery]Guid Id, PutUserDto PutUserDto)
        {
            if (ModelState.IsValid)
            {
                var userNew = new User()
                {
                    DisplayName = PutUserDto.DisplayName,
                    Email = PutUserDto.Email,
                    Phone = PutUserDto.Phone,
                    Address = PutUserDto.Address,
                    DateOfBirth = PutUserDto.DateOfBirth
                };
                return Ok(await _userRepository.EditUser(Id, userNew));

            }
            else
            {
                return BadRequest(ModelState.ErrorCount);
            }
        }
    }
}