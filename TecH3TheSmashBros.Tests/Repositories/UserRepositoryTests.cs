using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Database;
using TecH3TheSmashBros.API.Models;
using TecH3TheSmashBros.API.Repositories;
using Xunit;

namespace TecH3TheSmashBros.Tests.Repositories
{
        public class UserRepositoryTests
        {
            private readonly DbContextOptions<TecH3TheSmashBrosDbContext> _options;
            private readonly TecH3TheSmashBrosDbContext _context;

            
            public UserRepositoryTests()
            {
                _options = new DbContextOptionsBuilder<TecH3TheSmashBrosDbContext>()
                    .UseInMemoryDatabase(databaseName: "UserDatabase")
                    .Options;

                _context = new TecH3TheSmashBrosDbContext(_options);

                _context.Database.EnsureDeleted();
                _context.User.Add(new User
                {
                    Id = 1,
                    Email = "hejmeddig@123.dk",
                    Password = "1234"
                });
                _context.User.Add(new User
                {
                    Id = 2,
                    Email = "test@123.dk",
                    Password = "1234"
                }); _context.User.Add(new User
                {
                    Id = 3,
                    Email = "søddig@123.dk",
                    Password = "1234"
                });
                _context.SaveChanges();

            }
            [Fact]
            public async Task GetAllUsers()
            {
                // Arange
                UserRepository userRepository = new UserRepository(_context);

                // act
                var users = await userRepository.GetAllUsers();

                // Assert
                Assert.NotNull(users);
                Assert.Equal(3, users.Count);
            }
            [Fact]
            public async Task DeleteId_ShouldDeleteUser()
            {
                // Arange
                UserRepository userRepository = new UserRepository(_context);
                // Act
                int userId = 1;
                var user = await userRepository.DeleteUser(userId);
                // Assert
                Assert.NotNull(user);
                Assert.NotNull(user.DeletedAt);
            }
            [Fact]
            public async Task UpdateId_ShouldUpdateUser()
            {
                // Arange
                UserRepository userRepository = new UserRepository(_context);
                int userId = 1;
                User userupdate = new User
                {
                    Email = "hejmeddig@1234.dk",
                    Password = "123"
                };
                // Act
                var user = await userRepository.UpdateUser(1, userupdate);
                // Assert
                Assert.NotNull(user);
                Assert.Equal(userId, user.Id);
                Assert.Equal("hejmeddig@1234.dk", user.Email);
                Assert.Equal("123", user.Password);
                Assert.NotNull(user.UpdatedAt);

            }
            [Fact]
            public async Task Create_shouldcreateUser()
            {
                // arange
                UserRepository userRepository = new UserRepository(_context);
                User newuser = new User
                {
                    Email = "HejSødeDig@123.dk",
                    Password = "1234"
                };
                List<User> users = await userRepository.GetAllUsers();

                // act
                var user = await userRepository.CreateUser(newuser);

                // assert
                Assert.NotNull(user);
                Assert.NotEqual(DateTime.MinValue, user.CreatedAt);
                Assert.Equal(users.Count + 1, user.Id);
            }

        }

}
