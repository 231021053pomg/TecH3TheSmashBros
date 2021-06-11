using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Services
{
    public interface IUserService
    {

        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(int id, User user);

        Task<User> DeleteUser(int id);
        


        Task<List<Role>> GetAllRoles();
        Task<Role> CreateRole(Role role);
        Task<Role> DeleteRole(int id);

    }
}
