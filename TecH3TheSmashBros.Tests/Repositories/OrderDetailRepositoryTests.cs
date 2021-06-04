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
        public class OrderDetailRepositoryTests
        {
            private readonly DbContextOptions<TecH3TheSmashBrosDbContext> _options;
            private readonly TecH3TheSmashBrosDbContext _context;

            
            public OrderDetailRepositoryTests()
            {
                _options = new DbContextOptionsBuilder<TecH3TheSmashBrosDbContext>()
                    .UseInMemoryDatabase(databaseName: "OrderDetailDatabase")
                    .Options;

                _context = new TecH3TheSmashBrosDbContext(_options);

                _context.Database.EnsureDeleted();
                _context.OrderDetail.Add(new OrderDetail
                {
                    Id = 1,
                    Price = 14,
                    Amount = 1
                });
                _context.OrderDetail.Add(new OrderDetail
                {
                    Id = 2,
                    Price = 123,
                    Amount = 2
                }); _context.OrderDetail.Add(new OrderDetail
                {
                    Id = 3,
                    Price = 123,
                    Amount = 8
                });
                _context.SaveChanges();

            }
            [Fact]
            public async Task DeleteId_ShouldDeleteOrderDetail()
            {
                // Arange
                OrderDetailRepository orderdetailRepository = new(_context);
                // Act
                int orderdetailId = 1;
                var orderdetail = await orderdetailRepository.DeleteOrderDetail(orderdetailId);
                // Assert
                Assert.NotNull(orderdetail);
                Assert.NotNull(orderdetail.DeletedAt);
            }
            [Fact]
            public async Task UpdateId_ShouldUpdateOrderDetail()
            {
                // Arange
                OrderDetailRepository orderdetailRepository = new(_context);
                int orderdetailId = 1;
                OrderDetail orderdetailupdate = new()
                {
                    Price = 144,
                    Amount = 5
                };
                // Act
                var orderdetail = await orderdetailRepository.UpdateOrderDetail(1, orderdetailupdate);
                // Assert
                Assert.NotNull(orderdetail);
                Assert.Equal(orderdetailId, orderdetail.Id);
                Assert.Equal(144, orderdetail.Price);
                Assert.Equal(5, orderdetail.Amount);
                Assert.NotNull(orderdetail.UpdatedAt);

            }
            [Fact]
            public async Task Create_shouldcreateOrderDetail()
            {
                // arange
                OrderDetailRepository orderdetailRepository = new(_context);
                OrderDetail neworderdetail = new()
                {
                    Price = 123,
                    Amount = 2
                };

                // act
                var orderdetail = await orderdetailRepository.CreateOrderDetail(neworderdetail);

                // assert
                Assert.NotNull(orderdetail);
                Assert.NotEqual(DateTime.MinValue, orderdetail.CreatedAt);
                Assert.Equal(4, orderdetail.Id);
            }

        }

}
