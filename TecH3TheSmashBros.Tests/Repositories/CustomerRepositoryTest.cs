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
    public class CustomerRepositoryTests
    {
        private readonly DbContextOptions<TecH3TheSmashBrosDbContext> _options;
        private readonly TecH3TheSmashBrosDbContext _context;

        public CustomerRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<TecH3TheSmashBrosDbContext>()
                .UseInMemoryDatabase(databaseName: "CustomerDatabase")
                .Options;

            _context = new TecH3TheSmashBrosDbContext(_options);

            _context.Database.EnsureDeleted();
            _context.Customer.Add(new Customer
            {
                Id = 1,
                FirstName = "Berk",
                LastName = "Catal",
                Street = "Brøndbyvestervej 18",
                Zipcode = 2600,
                City = "Glostrup"
            });
            _context.Customer.Add(new Customer
            {
                Id = 2,
                FirstName = "Niklas",
                LastName = "Dahl",
                Street = "Buggati street ",
                Zipcode = 2900,
                City = "Hellerup"
            }); _context.Customer.Add(new Customer
            {
                Id = 3,
                FirstName = "Jack",
                LastName = "Conradsen",
                Street = "Ipadvej 40",
                Zipcode = 2640,
                City = "Hedehusene"
            });
            _context.SaveChanges();

        }
        [Fact]
        public async Task GetAllCustomers()
        {
            // Arange
            CustomerRepository customerRepository= new CustomerRepository(_context);

            // act
            var customer = await customerRepository.GetAllCustomer();

            // Assert
            Assert.NotNull(customer);
            Assert.Equal(3, customer.Count);
        }
        [Fact]
        public async Task DeleteId_ShouldDeleteCustomer()
        {
            // Arange
            CustomerRepository customerRepository = new CustomerRepository(_context);
            // Act
            int customerId = 1;
            var customer = await customerRepository.DeleteCustomer(customerId);
            // Assert
            Assert.NotNull(customer);
            Assert.Equal(customerId, customer.Id);
            Assert.NotNull(customer.DeletedAt);
        }
        [Fact]
        public async Task UpdateId_ShouldUpdateCustomer()
        {
            // Arange
            CustomerRepository customerRepository = new CustomerRepository(_context);
            int customerId = 1;
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
        [Fact]
        public async Task Create_shouldCreateCustommer()
        {
            // arange
            CustomerRepository customerRepository = new CustomerRepository(_context);
            Customer newcustomer = new Customer
            {
                FirstName = "Snop",
                LastName = "Dogg",
                Street = "WeedStreet",
                Zipcode = 4200,
                City = "Slagelse"
            };
            List<Customer> customers = await customerRepository.GetAllCustomer();

            // act
            var customer = await customerRepository.CreateCustomer(newcustomer);

            // assert
            Assert.NotNull(customer);
            Assert.NotEqual(DateTime.MinValue, customer.CreatedAt);
            Assert.Equal(customers.Count + 1, customer.Id);
        }

    }
}
