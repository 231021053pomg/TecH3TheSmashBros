using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Database;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly TecH3TheSmashBrosDbContext _sut;

        public RoleRepository(TecH3TheSmashBrosDbContext sut)
        {
            _sut = sut;
        }
        public async Task<List<Role>> GetAllRoles()
        {
            return await _sut.Role
                .Where(a => a.DeletedAt == null)
                .ToListAsync();
        }
        public async Task<Role> GetRoleById(int id)
        {
            return await _sut.Role
                .Where(a => a.DeletedAt == null)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<Role> CreateRole(Role role)
        {
            role.CreatedAt = DateTime.Now;
            _sut.Role.Add(role);
            await _sut.SaveChangesAsync();
            return role;
        }
        public async Task<Role> UpdateRole(int id, Role role)
        {
            var editRole = await _sut.Role.FirstOrDefaultAsync(a => a.Id == id);
            if (editRole != null)
            {
                editRole.UpdatedAt = DateTime.Now;
                editRole.RoleName = role.RoleName;
                _sut.Role.Update(editRole);
                await _sut.SaveChangesAsync();
            }
            return editRole;
        }
        public async Task<Role> DeleteRole(int id)
        {
            var role = await _sut.Role.FirstOrDefaultAsync(a => a.Id == id);
            if (role != null)
            {
                role.DeletedAt = DateTime.Now;
                await _sut.SaveChangesAsync();
            }
            return role;
        }
    }
}
