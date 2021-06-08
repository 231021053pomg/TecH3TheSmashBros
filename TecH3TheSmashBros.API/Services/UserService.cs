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
        public async Task<List<User>> GetAllById()
        {
            var users = await _userRepository.GetAllUsers();
            return users;
        }
        public async Task<User> GetUserById(int id)
        {
            var users = await _userRepository.GetUserById(id);
            return users;
        }
        public async Task<User> CreateUser(User user, Role role)
        {
            var newUser = await _userRepository.CreateUser(user);
            return newUser;
        }
        public async Task<User> CreateUser(User user, Role role, Customer customer)
        {
            var newUser = await _userRepository.CreateUser(user);
            return newUser;
        }
        public async Task<User> UpdateUser(int id, Role role)
        {
            var editUpdate = await _userRepository.UpdateUser(id);
            
            return editUpdate;
        }
        public async Task<User> UpdateUser(int id, Role role, Customer customer)
        {
            var editUpdate = await _userRepository.UpdateUser(id, role, customer);
            return editUpdate;
        }
        public async Task<User> DeleteUser(int id, Role role)
        {
            var user = await _userRepository.DeleteUser(id);
            return user;
        }


    }
}
