using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Database;
using TecH3TheSmashBros.API.Models;
using Microsoft.EntityFrameworkCore;

namespace TecH3TheSmashBros.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TecH3TheSmashBrosDbContext _sut;
        public CustomerRepository(TecH3TheSmashBrosDbContext sut)
        {
            _sut = sut;

        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            customer.CreateAt = DateTime.Now;
            _sut.Customer.Add(customer);
            await _sut.SaveChangesAsync();
            return customer;
        }


        public async Task<List<Customer>> GetAllCustomer()
        {
            return await _sut.Customer
                .Where(a => a.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<Customer> UpdateCustomer(int id, Customer customer)
        {
            var editcustomer = await _sut.Customer.FirstOrDefaultAsync(a => a.Id == id);
            if (editcustomer != null)
            {
                editcustomer.UpdatedAt = DateTime.Now;
                editcustomer.FirstName = customer.FirstName;
                editcustomer.LastName = customer.LastName;
                editcustomer.Street = customer.Street;
                editcustomer.City = customer.City;
                editcustomer.Zipcode = customer.Zipcode;
                _sut.Customer.Update(editcustomer);
                await _sut.SaveChangesAsync();
            }
            return editcustomer;
        }
        public async Task<Customer> DeleteCustomer(int id)
        {
            var costumer = await _sut.Customer.FirstOrDefaultAsync(a => a.Id == id);
            if (costumer != null)
            {
                costumer.DeletedAt = DateTime.Now;
                await _sut.SaveChangesAsync();
            }
            return costumer;
        }
    }
}
