using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(Order order);
        Task<List<Order>> GetAllOrders();
        Task<Order> GetById(int id);
        Task<Order> UpdateOrder(int id, Order order);
        Task<Order> DeleteOrder(int id);
    }
}
