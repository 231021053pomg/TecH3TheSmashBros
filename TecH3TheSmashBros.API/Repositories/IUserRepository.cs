using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();

        Task<List<User>> GetAllUsersByRole( int roleid);

        Task<User> GetUserById(int id);

        Task<User> CreateUser(User user);

        Task<User> UpdateUser(int id, User user);

        Task<User> DeleteUser(int id);

    }
}
