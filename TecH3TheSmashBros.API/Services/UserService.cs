using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;
using TecH3TheSmashBros.API.Repositories;

namespace TecH3TheSmashBros.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ICustomerRepository _customerRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, ICustomerRepository customerRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _customerRepository = customerRepository;
        }
        public async Task<List<User>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return users;
        }
        public async Task<User> GetUserById(int id)
        {
            var users = await _userRepository.GetUserById(id);
            return users;
        }
        public async Task<User> CreateUser(User user)
        {
            var newUser = await _userRepository.CreateUser(user);
            return newUser;
        }
        public async Task<User> UpdateUser(int id, User user)
        {
            var editUpdate = await _userRepository.UpdateUser(id, user);

            return editUpdate;
        }
       
        public async Task<User> DeleteUser(int id)
        {
            var user = await _userRepository.DeleteUser(id);
            return user;
        }



        public async Task<List<Role>> GetAllRoles()
        {
            var roles = await _roleRepository.GetAllRoles();
            return roles;
        }

        public async Task<Role> CreateRole(Role role)
        {
            var newRole = await _roleRepository.CreateRole(role);
            return newRole;
        }

        public async Task<Role> DeleteRole(int id)
        {
            var role = await _roleRepository.DeleteRole(id);
            return role;
        }
    }
}
