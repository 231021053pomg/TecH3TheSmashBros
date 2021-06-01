using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    interface IUserRepositories
    {
        Task<List<User>> GetAllUsers();

        Task<User> GetUserById(int id);

        Task<User> CreateUser(User users);

        Task<User> UpdateUser(int id, User users);

        Task<User> DeleteUser(int id);

    }
}
