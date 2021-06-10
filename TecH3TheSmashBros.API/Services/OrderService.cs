using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;
using TecH3TheSmashBros.API.Repositories;

namespace TecH3TheSmashBros.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderdetailsRepository;
        public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetail)
        {
            _orderRepository = orderRepository;
            _orderdetailsRepository = orderDetail;
        }

        public async Task<List<Order>> GetAllOrder()
        {
            var orders = await _orderRepository.GetAllOrders();
            return orders;
        }

        public async Task<Order> GetOrderById(int id)
        {
            var orders = await _orderRepository.GetById(id);
            return orders;
        }
        public async Task<Order> Create(Order order, List<OrderDetail> orderDetails)
        {
            var newOrder = await _orderRepository.CreateOrder(order);
            return newOrder;
        }
        public async Task<Order> Update(int id, Order order, List<OrderDetail> orderDetails)
        {
            var updateorder = await _orderRepository.UpdateOrder(id, order);
            return updateorder;
        }
        public async Task<Order> Delete(int id)
        {
            var orders = await _orderRepository.DeleteOrder(id);
            return orders;
        }
    }
}
