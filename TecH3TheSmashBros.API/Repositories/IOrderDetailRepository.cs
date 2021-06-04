using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetail> CreateOrderDetail(OrderDetail orderDetail);

        Task<OrderDetail> UpdateOrderDetail(int id, OrderDetail orderDetail);

        Task<OrderDetail> DeleteOrderDetail(int id);

        Task<List<OrderDetail>> GetAllOrderDetailsByOrder(int orderNumberId);

    }
}
