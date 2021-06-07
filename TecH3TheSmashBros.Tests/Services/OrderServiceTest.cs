using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using TecH3TheSmashBros.API.Services;
using TecH3TheSmashBros.API.Repositories;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.Tests.Services
{

    public class OrderServiceTest
    {
    private readonly OrderService _sut;
    private readonly Mock<IOrderRepository> _OrderServicesMock = new();
    private readonly Mock<IOrderDetailRepository> _OrderDetailServiceMock = new();
        public OrderServiceTest()
        {
            _sut = new OrderService(_OrderServicesMock.Object, _OrderDetailServiceMock.Object);
        }
        [Fact]
        public async Task GetByid_shouldreturnNull_whenOrderDoesNotExist()
        {
            // Arange
            _OrderServicesMock
                .Setup(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            // Act
            var order = await _sut.GetOrderById(123);

            // Assert
            Assert.Null(order);
        }
        [Fact]
        public async Task GetById_shouldReturnOrder_whenOrderExists()
        {
            // Arange
            int id = 1;
            int UserId = 1;
            DateTime Date = new DateTime(2021,07,06);

            Order mockOrder = new Order
            {
            Id = id,
            UserId = UserId,
            Date = Date 
            };
            _OrderServicesMock
                .Setup(x => x.GetById(mockOrder.Id))
                .ReturnsAsync(mockOrder);

            // Act
            var order = await _sut.GetOrderById(mockOrder.Id);


            // Assert
            Assert.NotNull(order);
            Assert.Equal(id, order.Id);
            Assert.Equal(UserId, order.UserId);
            Assert.Equal(Date, order.Date);

        }
        [Fact]
        public async Task ListAllOrders()
        {
            // Arange
            List<Order> newlist = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    UserId = 1,
                    CreatedAt = new DateTime(1999,08,30),
                    Date = new DateTime(1999,08,12)
                },
                new Order
                {
                    Id = 2,
                    UserId = 2,
                    CreatedAt = new DateTime(1999, 09, 30),
                    Date = new DateTime(2021,09,30)
                }
            };
            _OrderServicesMock
                .Setup(x => x.GetAllOrders())
                .ReturnsAsync(newlist);
            // Act
            var order = await _sut.GetAllOrder();


            // Assert
            Assert.Equal(newlist, order);
        }
    }
}
