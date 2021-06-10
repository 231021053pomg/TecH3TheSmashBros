using System;
using Xunit;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Database;
using Microsoft.EntityFrameworkCore;
using TecH3TheSmashBros.API.Models;
using TecH3TheSmashBros.API.Repositories;
using System.Collections.Generic;
using TecH3TheSmashBros.API.Controllers;
using TecH3TheSmashBros.API.Services;
using Moq;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace TecH3TheSmashBros.Tests.Controller
{
    public class OrderControllerTest
    {
        private readonly OrderController _sut;
        private readonly Mock<IOrderService> _orderServiceMock = new();

        public OrderControllerTest()
        {
            _sut = new OrderController(_orderServiceMock.Object);
        }
        [Fact]
        public async Task GetAll_ShouldReturn200_WhenDataExists()
        {
            // Arange
            List<Order> orders = new List<Order>();

            orders.Add(new Order());
            orders.Add(new Order());

            _orderServiceMock
                .Setup(x => x.GetAllOrder())
                .ReturnsAsync(orders);

            // Act
            var result = await _sut.GetAll();

            // Assert
            var StatsusCodeResuslt = (IStatusCodeActionResult)result;
            Assert.Equal(200, StatsusCodeResuslt.StatusCode);
        }
        [Fact]
        public async Task GetAll_ShouldReturn204_WhenDataIsEmpty()
        {
            // Arange
            List<Order> orders = new List<Order>();


            _orderServiceMock
                .Setup(x => x.GetAllOrder())
                .ReturnsAsync(orders);

            // Act
            var result = await _sut.GetAll();

            // Assert
            var StatsusCodeResuslt = (IStatusCodeActionResult)result;
            Assert.Equal(204, StatsusCodeResuslt.StatusCode);
        }
        [Fact]
        public async Task GetAll_ShouldReturn500_WhenDataExists()
        {
            // Arange
            _orderServiceMock
                .Setup(x => x.GetAllOrder())
                .ReturnsAsync(() => null);

            // Act
            var result = await _sut.GetAll();

            // Assert
            var StatsusCodeResuslt = (IStatusCodeActionResult)result;
            Assert.Equal(500, StatsusCodeResuslt.StatusCode);
        }
        [Fact]
        public async Task Create_ShouldReturnStatus200_WhenOrderSubmitIsOk()
        {
            // Arrange
            Order order = new Order
            {
                Id = 2,
                UserId = 2,
                Date = new DateTime(2009, 07, 22),
                CreatedAt = new DateTime(2009, 07, 22)
            };
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            orderDetails.Add(new OrderDetail
            {
                Price = 2,
                Amount = 5,
                Id = 1,
                CreatedAt = new DateTime(2009, 07, 22),
                OrderId = 1
            });
            _orderServiceMock
                .Setup(s => s.Create(It.IsAny<Order>()))
                .ReturnsAsync(order);

            // Act
            var response = await _sut.CreateOrder(order);

            // Assert
            // specifikt se på det ObjectResult der kommer fra _controller
            var responseStatusCode = (IStatusCodeActionResult)response;
            Assert.Equal(200, responseStatusCode.StatusCode);
        }


        [Fact]
        public async Task GetOrderById_ShouldReturnOrder_WhenOrderExists()
        {
            // Arrange
            int id = 1;
            int userid = 1;
            DateTime date = new DateTime(2011, 08, 30);
            DateTime createdat = new DateTime(2011, 09, 30);

            Order order = new Order
            {
                Id = id,
                UserId = userid,
                Date = date,
                CreatedAt = createdat

            };

            _orderServiceMock
                .Setup(s => s.GetOrderById(It.IsAny<int>()))
                .ReturnsAsync(order);

            // Act
            var response = await _sut.Get(id);

            // Assert
            Assert.NotNull(response);
        }
    }
}
