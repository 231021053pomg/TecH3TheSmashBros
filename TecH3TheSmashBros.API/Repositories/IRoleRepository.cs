using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    public interface IRoleRepository
    {

        Task<List<Role>> GetAllRoles();

        Task<Role> GetRoleById(int id);

        Task<Role> CreateRole(Role role);

        Task<Role> UpdateRole(int id, Role role);

        Task<Role> DeleteRole(int id);

    }
}
