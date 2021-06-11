using System;
using Xunit;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Database;
using Microsoft.EntityFrameworkCore;
using TecH3TheSmashBros.API.Models;
using TecH3TheSmashBros.API.Repositories;
using System.Collections.Generic;
using TecH3TheSmashBros.API.Controllers;
using Moq;
using TecH3TheSmashBros.API.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace TecH3TheSmashBros.Tests
{
    public class UserControllerTests
    {
        private readonly UserController _sut;
        private readonly Mock<IUserService> _userServiceMock = new();
        public UserControllerTests()
        {
            _sut = new UserController(_userServiceMock.Object);
        }

        #region GetAllUsers 2/3
        [Fact]
        public async Task GetAll_shouldReturn200_WhenDataExists()
        {
            //Arrange
            List<User> users = new List<User>();
            for (int i = 0; i < 5; i++)
            {
                users.Add(new User());
            }
            _userServiceMock
                .Setup(x => x.GetAllUsers())
                .ReturnsAsync(users);

            //Act
            var result = await _sut.GetAllUsers();

            //Assert
            var StatusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, StatusCodeResult.StatusCode);


        }

        [Fact]
        public async Task GetAll_shouldReturn204_IfServiceReturnEmptyList()
        {
            //Arrange
            List<User> users = new List<User>();

            _userServiceMock
                .Setup(x => x.GetAllUsers())
                .ReturnsAsync(users);

            //Act
            var result = await _sut.GetAllUsers();

            //Assert
            var StatusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, StatusCodeResult.StatusCode);
        }

        //[Fact]
        //public async Task GetAll_shouldReturn500_IfServiceReturnNull()
        //{
        //    //Arrange

        //    //Act

        //    //Assert
        //}
        //#endregion

        //#region GetUserById 1/3
        //[Fact]
        //public async Task GetById_ShouldReturn200_WhenDataExists()
        //{
        //    //Arrange

        //    _userServiceMock
        //        .Setup(x => x.GetUserById(It.IsAny<int>()))
        //        .ReturnsAsync(() => null);

        //    //Act
        //    var user = await _sut.GetById(1);
        //    //Assert
        //    var StatusCodeResult = (IStatusCodeActionResult)user;
        //    Assert.Equal(200, StatusCodeResult.StatusCode);
        //}

        //[Fact]
        //public async Task GetId_ShouldReturn404_WhenDataExists()
        //{

        //}

        //[Fact]
        //public async Task GetId_ShouldReturn500_WhenDataExists()
        //{ }
        #endregion

        #region UpdateUser 1/4
        [Fact]
        public async Task Update_ShouldReturn200_WhenDataExists()
        {
            //Arrange
            List<User> users = new List<User>();
            for (int i = 0; i < 5; i++)
            {
                users.Add(new User());
            }
            _userServiceMock
                .Setup(x => x.GetAllUsers())
                .ReturnsAsync(users);

            //Act
            var result = await _sut.GetAllUsers();

            //Assert
            var StatusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, StatusCodeResult.StatusCode);


        }
        #endregion

        #region DeleteUser 0/4

        #endregion

    }
}
