using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API;
using TecH3TheSmashBros.API.Models;
using TecH3TheSmashBros.API.Services;

namespace TecH3TheSmashBros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #region Users
        //Gets all Users
        // https://localhost:5001/api/user
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                // throw new Exception("Should Fail...");
                if (users.Count == 0) return NoContent();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var getUser = await _userService.GetUserById(id);

            if (getUser != null) { return Ok(getUser); }
            else return null;


        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User Fail....");
                }
                var newUser = await _userService.CreateUser(user);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] User user)
        {
            var updateUser = await _userService.UpdateUser(id, user);
            return Ok(updateUser);

        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var deleteUser = await _userService.DeleteUser(id);
            return Ok(deleteUser);
        }
#endregion

        #region Roles

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var roles = await _userService.GetAllRoles();
                // throw new Exception("Should Fail...");
                if (roles.Count == 0) return NoContent();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(Role role)
        {
            try
            {
                if (role == null)
                {
                    return BadRequest("User Fail....");
                }
                var newRole = await _userService.CreateRole(role);
                return Ok(newRole);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole([FromRoute] int id)
        {
            var deleteRole = await _userService.DeleteRole(id);
            return Ok(deleteRole);
        }
        #endregion
        
        

    }
}
