using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;
using TecH3TheSmashBros.API.Repositories;
using TecH3TheSmashBros.API.Services;
using Xunit;

namespace TecH3TheSmashBros.Tests.Repositories
{
    public class UserServiceTests
    {
        private readonly UserService _sut;
        private readonly Mock<IUserRepository> _userRepositoryMock = new();
        private readonly Mock<IRoleRepository> _roleRepositoryMock = new();
        private readonly Mock<ICustomerRepository> _customerRepositoryMock = new();


        public UserServiceTests()
        {
            _sut = new UserService(_userRepositoryMock.Object, _roleRepositoryMock.Object, _customerRepositoryMock.Object);
            _sut.User.Add(new User
            {
                Id = 1,
                Email = "Albert",
                Password = "Andersen"
            });
        }
        [Fact]
        public async Task GetById_ShouldReturnNull_WhenUserDoesNotExist()
        {
            //Arrange
            _userRepositoryMock
                .Setup(x => x.GetUserById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var user = await _sut.GetUserById(123);
            //Assert
            Assert.Null(user);
        }

        [Fact]
        public async Task GetById_ShouldReturnUser_WhenUserExists()
        {
            //Arrange
            int id = 1;
            string email = "albert@andersen.dk";
            string password = "1234";
            User mockUser = new User()
            {
                Id = id,
                Email = email,
                Password = password
            };

            _userRepositoryMock
                .Setup(x => x.GetUserById(mockUser.Id))
                .ReturnsAsync(mockUser);

            //Act
            var user = await _sut.GetUserById(mockUser.Id);

            //Assert
            Assert.NotNull(user);
            Assert.Equal(id, user.Id);
            Assert.Equal(email, user.Email);
            Assert.Equal(password, user.Password);

        }

        [Fact]
        public async Task GetAllUser_ShouldReturnUsers_WhenUsersExists()
        {
            //Arrange
            List<User> newList = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "albert@andersen.dk",
                    Password = "1234"
                },
                new User
                {
                    Id = 2,
                    Email = "berit@bøg.dk",
                    Password = "1234"
                },
                new User
                {
                    Id = 3,
                    Email = "carl@christensen.dk",
                    Password = "1234"
                }
            };
            _userRepositoryMock
                .Setup(x => x.GetAllUsers())
                .ReturnsAsync(newList);

            //Act
            var user = await _sut.GetAllUsers();

            //Assert
            Assert.Equal(user, newList);
        }

        [Fact]
        public async Task Create_ShouldReturnUser_WhenUserIsCreated()
        {
            //Arrange

            Role createdRole = new Role
            {
                Id = 1,
                RoleName = "Admin"
            };

            User newUser = new User
            {
                Email = "dennis@delight.dk",
                Password = "1234",
            };
            User createdUser = new User
            {
                Id = 1,
                Email = "dennis@delight.dk",
                Password = "1234",
                CreatedAt = DateTime.Now,
                RoleId = 1
            };
            _userRepositoryMock
                .Setup(x => x.CreateUser(It.IsAny<User>()))
                .ReturnsAsync(createdUser);

            //Act
            var user = await _sut.CreateUser(newUser,createdRole);
            //Assert
            Assert.NotNull(user);
            Assert.NotEqual(DateTime.MinValue, user.CreatedAt);

        }
        
            [Fact]
        public async Task Update_ShouldReturnUser_WhenUserIsUpdated()
        {
            //Arrange
            
            int id = 1;
            Role createdRole = new Role
            {
                Id = 1,
                RoleName = "Admin"
            };
            User updateUser = new User { Email = "albert@andersen.dk", Password = "1234" };
            //Act
            var user = await _sut.UpdateUser(id,updateUser,createdRole);
            //Assert
            Assert.NotNull(user);
            Assert.Equal(id, user.Id);
            Assert.Equal(updateUser.Email, user.Email);
            Assert.Equal(updateUser.Password, user.Password);
            Assert.NotNull(user.UpdatedAt);
        }
        [Fact]
        public async Task Delete_ShouldReturnUser_WhenUserIsDeleted()
        {
            //Arrange

            //Act

            //Assert
        }

    }

}
