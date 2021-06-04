using System;
using Xunit;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Database;
using Microsoft.EntityFrameworkCore;
using TecH3TheSmashBros.API.Models;
using TecH3TheSmashBros.API.Repositories;
using System.Collections.Generic;

namespace TecH3TheSmashBros.Tests.Repositories
{
    public class OrderRepositoryTest
    {
        private readonly DbContextOptions<TecH3TheSmashBrosDbContext> _options;
        private readonly TecH3TheSmashBrosDbContext _context;

        public OrderRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<TecH3TheSmashBrosDbContext>()
                .UseInMemoryDatabase(databaseName: "OrderDatabase")
                .Options;

            _context = new TecH3TheSmashBrosDbContext(_options);

            _context.Database.EnsureDeleted();
            _context.Order.Add(new Order
            {
                Id = 1,
                UserId = 1,
                Date = new DateTime(2016, 12, 31)
            });
            _context.Order.Add(new Order
            {
                Id = 2,
                UserId = 2,
                Date = new DateTime(2020, 08, 30)
            }); _context.Order.Add(new Order
            {
                Id = 3,
                UserId = 3,
                Date = new DateTime(2021, 04, 06)
            });
            _context.SaveChanges();
        }
        [Fact]
        public async Task GetAllOrder()
        {
            // Arange
            OrderRepository orderRepository = new OrderRepository(_context);

            // act
            var order = await orderRepository.GetAllOrders();

            // Assert
            Assert.NotNull(order);
            Assert.Equal(3, order.Count);
        }
        [Fact]
        public async Task DeleteId_ShouldDeleteOrder()
        {
            // Arange
            OrderRepository orderRepository = new OrderRepository(_context);
            // Act
            int orderId = 1;
            var order = await orderRepository.DeleteOrder(orderId);
            // Assert
            Assert.NotNull(order);
            Assert.Equal(orderId, order.Id);
            Assert.NotNull(order.DeletedAt);
        }
        [Fact]
        public async Task UpdateId_ShouldUpdateOrder()
        {
            // Arange
            OrderRepository orderRepository = new OrderRepository(_context);
            int orderId = 1;
            Order orderupdate = new Order
            {
                Id = 1,
                UserId = 1,
                Date = new DateTime(2013, 12, 05)
            };
            // Act
            var order = await orderRepository.UpdateOrder(1, orderupdate);
            // Assert
            Assert.NotNull(order);
            Assert.NotNull(order.UpdatedAt);
            Assert.Equal(orderId, order.Id);
        }
        [Fact]
        public async Task Create_shouldCreateOrder()
        {
            // arange
            OrderRepository orderRepository = new OrderRepository(_context);
            Order newOrder = new Order
            {
                Date = new DateTime(2015, 12, 31)
            };
            
            List<Order> orders = await orderRepository.GetAllOrders();

            // act
            var order = await orderRepository.CreateOrder(newOrder);

            // assert
            Assert.NotNull(order);
            Assert.NotEqual(DateTime.MinValue, order.CreatedAt);
            Assert.Equal(orders.Count + 1, order.Id);
        }
    }
}
