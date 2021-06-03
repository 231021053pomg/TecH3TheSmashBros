using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Database;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TecH3TheSmashBrosDbContext _sut;

        public UserRepository(TecH3TheSmashBrosDbContext sut)
        {
            _sut = sut;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _sut.User
                .Where(a => a.DeletedAt == null)
                .ToListAsync();
        }
        public async Task<List<User>> GetAllUsersByRole(int roleid)
        {
            return await _sut.User
                .Where(a => a.DeletedAt == null && a.RoleId == roleid)
                .ToListAsync();
        }
        public async Task<User> GetUserById(int id)
        {
            return await _sut.User
                .Where(a => a.DeletedAt == null)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<User> CreateUser(User user)
        {
            user.CreatedAt = DateTime.Now;
            _sut.User.Add(user);
            await _sut.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateUser(int id, User user)
        {
            var editUser = await _sut.User.FirstOrDefaultAsync(a => a.Id == id);
            if (editUser != null)
            {
                editUser.UpdatedAt = DateTime.Now;
                editUser.Email = user.Email;
                editUser.Password = user.Password;
                _sut.User.Update(editUser);
                await _sut.SaveChangesAsync();
            }
            return editUser;
        }
        public async Task<User> DeleteUser(int id)
        {
            var user = await _sut.User.FirstOrDefaultAsync(a => a.Id == id);
            if (user != null)
            {
                user.DeletedAt = DateTime.Now;
                await _sut.SaveChangesAsync();
            }
            return user;
        }


    }
}
