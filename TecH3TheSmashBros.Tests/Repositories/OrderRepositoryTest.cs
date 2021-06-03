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
                Date = 03 - 06 - 2021
            });
            _context.Order.Add(new Order
            {
                Id = 2,
                UserId = 2,
                Date = 02 - 06 - 2021
            }); _context.Order.Add(new Order
            {
                Id = 3,
                UserId = 3,
                Date = 01 - 06 - 2021
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
            Customer customerupdate = new Customer
            {
                FirstName = "Recep Berk",
                LastName = "Catal"
            };
            // Act
            var customer = await customerRepository.UpdateCustomer(1, customerupdate);
            // Assert
            Assert.NotNull(customer);
            Assert.Equal(customerId, customer.Id);
            Assert.Equal("Recep Berk", customer.FirstName);
            Assert.Equal("Catal", customer.LastName);
            Assert.NotNull(customer.UpdatedAt);

        }
    }
}
