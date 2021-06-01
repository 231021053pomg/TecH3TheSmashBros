using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    interface IUserRepositories
    {
        Task<List<Users>> GetAllUsers();

        Task<Users> GetUserById(int id);

        Task<Users> CreateUser(Users users);

        Task<Users> UpdateUser(int id, Users users);

        Task<Users> DeleteUser(int id);

    }
}
