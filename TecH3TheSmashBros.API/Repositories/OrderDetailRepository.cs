using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Database;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {

        private readonly TecH3TheSmashBrosDbContext _sut;

        public OrderDetailRepository(TecH3TheSmashBrosDbContext sut)
        {
            _sut = sut;
        }
        public async Task<List<OrderDetailRepository>> GetAllOrderDetails()
        {
            return await _sut.OrderDetail
                .Where(a => a.DeletedAt == null)
                .ToListAsync();
        }
        public async Task<OrderDetailRepository> GetOrderDetailById(int id)
        {
            return await _sut.OrderDetail
                .Where(a => a.DeletedAt == null)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<OrderDetailRepository> CreateOrderDetail(OrderDetail orderdetail)
        {
            orderdetail.CreatedAt = DateTime.Now;
            _sut.OrderDetail.Add(orderdetail);
            await _sut.SaveChangesAsync();
            return orderdetail;
        }
        public async Task<OrderDetailRepository> UpdateOrderDetail(int id, OrderDetail orderdetail)
        {
            var editOrderDetail = await _sut.OrderDetail.FirstOrDefaultAsync(a => a.Id == id);
            if (editOrderDetail != null)
            {
                editOrderDetail.UpdatedAt = DateTime.Now;
                editOrderDetail.ProductsId = orderdetail.ProductsId;
                editOrderDetail.Price = orderdetail.Price;
                editOrderDetail.Amount = orderdetail.Amount;
                _sut.OrderDetail.Update(editOrderDetail);
                await _sut.SaveChangesAsync();
            }
            return editOrderDetail;
        }
        public async Task<OrderDetailRepository> DeleteOrderDetail(int id)
        {
            var orderdetail = await _sut.OrderDetail.FirstOrDefaultAsync(a => a.Id == id);
            if (orderdetail != null)
            {
                orderdetail.DeletedAt = DateTime.Now;
                await _sut.SaveChangesAsync();
            }
            return orderdetail;
        }
        public async Task<List<OrderDetailRepository>> GetAllOrderDetailsByOrder(int orderNumberId)
        {
            return await _sut.OrderDetail
                .Where(a => a.DeletedAt == null && a.OrderId == orderNumberId)
                .ToListAsync();
        }


    }
}
