using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateCustomer(Customer customer);
        Task<List<Customer>> GetAllCustomer();
        Task<Customer> UpdateCustomer(int id, Customer customer);
        Task<Customer> DeleteCustomer(int id);
    }
}
