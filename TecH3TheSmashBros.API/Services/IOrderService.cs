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
        Task<Order> Create(Order order, List<OrderDetail> orderDetails);
        Task<Order> Update(int id, Order order, List<OrderDetail> orderDetails);
        Task<Order> Delete(int id);
    }
}
