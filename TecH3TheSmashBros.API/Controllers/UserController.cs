using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;
using TecH3TheSmashBros.API.Services;

namespace TecH3TheSmashBros.API.Controllers
{
    [Route("api/")]
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
        [HttpGet("user")]
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
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var getUser = await _userService.GetUserById(id);

            if (getUser != null) { return Ok(getUser); }
            else return null;


        }
        [HttpPost("user")]
        public async Task<IActionResult> CreateUser( User user)
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

        [HttpPut("user/{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] User user)
        {
            var updateUser = await _userService.UpdateUser(id, user);
            return Ok(updateUser);

        }

        [HttpDelete("user/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var deleteUser = await _userService.DeleteUser(id);
            return Ok(deleteUser);
        }
        #endregion

        #region Roles

        [HttpGet("roles")]
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
        [HttpPost("roles")]
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
        [HttpDelete("roles/{id}")]
        public async Task<IActionResult> DeleteRole([FromRoute] int id)
        {
            var deleteRole = await _userService.DeleteRole(id);
            return Ok(deleteRole);
        }
        #endregion



    }
}
