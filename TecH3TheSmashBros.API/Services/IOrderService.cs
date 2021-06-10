using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrder();
        Task<Order> GetOrderById(int id);
        Task<Order> Create(Order order);
        Task<Order> Update(int id, Order order);
        Task<Order> Delete(int id);
    }
}
