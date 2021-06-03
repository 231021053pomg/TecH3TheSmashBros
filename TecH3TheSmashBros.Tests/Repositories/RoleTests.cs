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
        public class RoleRepositoryTests
        {
            private readonly DbContextOptions<TecH3TheSmashBrosDbContext> _options;
            private readonly TecH3TheSmashBrosDbContext _context;

            
            public RoleRepositoryTests()
            {
                _options = new DbContextOptionsBuilder<TecH3TheSmashBrosDbContext>()
                    .UseInMemoryDatabase(databaseName: "RoleDatabase")
                    .Options;

                _context = new TecH3TheSmashBrosDbContext(_options);

                _context.Database.EnsureDeleted();
                _context.Role.Add(new Role
                {
                    Id = 1,
                    RoleName = "User"                   
                });
                _context.Role.Add(new Role
                {
                    Id = 2,
                    RoleName = "Admin"                   
                }); _context.Role.Add(new Role
                {
                    Id = 3,
                    RoleName = "SuperMan"                  
                });
                _context.SaveChanges();

            }
            [Fact]
            public async Task GetAllRoles()
            {
                // Arange
                RoleRepository roleRepository = new RoleRepository(_context);

                // act
                var roles = await roleRepository.GetAllRoles();

                // Assert
                Assert.NotNull(roles);
                Assert.Equal(3, roles.Count);
            }
            [Fact]
            public async Task DeleteId_ShouldDeleteRole()
            {
                // Arange
                RoleRepository roleRepository = new RoleRepository(_context);
                // Act
                int roleId = 1;
                var role = await roleRepository.DeleteRole(roleId);
                // Assert
                Assert.NotNull(role);
                Assert.NotNull(role.DeletedAt);
            }
            [Fact]
            public async Task UpdateId_ShouldUpdateRole()
            {
                // Arange
                RoleRepository roleRepository = new RoleRepository(_context);
                int roleId = 1;
                Role roleupdate = new Role
                {
                    RoleName = "UserOne"
                };
                // Act
                var role = await roleRepository.UpdateRole(1, roleupdate);
                // Assert
                Assert.NotNull(role);
                Assert.Equal(roleId, role.Id);
                Assert.Equal("UserOne", role.RoleName);
                Assert.NotNull(role.UpdatedAt);

            }
            [Fact]
            public async Task Create_shouldcreateRole()
            {
                // arange
                RoleRepository roleRepository = new RoleRepository(_context);
                Role newrole = new Role
                {
                    RoleName = "User"
                };
                List<Role> roles = await roleRepository.GetAllRoles();

                // act
                var role = await roleRepository.CreateRole(newrole);

                // assert
                Assert.NotNull(role);
                Assert.NotEqual(DateTime.MinValue, role.CreatedAt);
                Assert.Equal(roles.Count + 1, role.Id);
            }

        }

}
