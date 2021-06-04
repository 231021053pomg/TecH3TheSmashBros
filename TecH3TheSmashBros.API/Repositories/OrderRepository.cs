using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Database;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TecH3TheSmashBrosDbContext _sut;
        public OrderRepository(TecH3TheSmashBrosDbContext sut)
        {
            _sut = sut;

        }

        public async Task<Order> CreateOrder(Order order)
        {
            order.CreatedAt = DateTime.Now;
            _sut.Order.Add(order);
            await _sut.SaveChangesAsync();
            return order;
        }

        public async Task<Order> DeleteOrder(int id)
        {
            var order = await _sut.Order.FirstOrDefaultAsync(a => a.Id == id);
            if (order != null)
            {
                order.DeletedAt = DateTime.Now;
                await _sut.SaveChangesAsync();
            }
            return order;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _sut.Order
                .Where(a => a.DeletedAt == null)
                .Include(a => a.OrderDetails)
                .ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _sut.Order
                .Where(a => a.DeletedAt == null)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Order> UpdateOrder(int id, Order order)
        {
            var editOrder = await _sut.Order.FirstOrDefaultAsync(a => a.Id == id);
            if (editOrder != null)
            {
                editOrder.UpdatedAt = DateTime.Now;
                editOrder.Date = order.Date;
                _sut.Order.Update(editOrder);
                await _sut.SaveChangesAsync();
            }
            return editOrder;
        }
    }
}
