using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    interface IOrderDetailRepository
    {
        Task<List<OrderDetailRepository>> GetAllOrderDetails();

        Task<OrderDetailRepository> GetOrderDetailById(int id);

        Task<OrderDetailRepository> CreateOrderDetail(OrderDetail orderdetail);

        Task<OrderDetailRepository> UpdateOrderDetail(int id, OrderDetail orderdetail);

        Task<OrderDetailRepository> DeleteOrderDetail(int id);

        Task<List<OrderDetailRepository>> GetAllOrderDetailsByOrder(int orderNumberId);

    }
}
