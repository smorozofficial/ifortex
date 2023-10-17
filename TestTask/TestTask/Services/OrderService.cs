using Microsoft.EntityFrameworkCore;
using System;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
	public class OrderService : IOrderService
	{
        private readonly ApplicationDbContext dbContext;

        public OrderService(ApplicationDbContext dbContext)
		{
            this.dbContext = dbContext;
        }

        public Task<Order> GetOrder()
        {

            Order order = new();
            dbContext.Orders.ToList().ForEach(item => 
            {
                if (order.Price * order.Quantity < item.Price * item.Quantity)
                {
                    order = item;
                }
            });

            return Task<Order>.Factory.StartNew(() => order);
        }

        public Task<List<Order>> GetOrders()
        {
            List<Order> orders = this.dbContext.Orders.Where(order => order.Quantity > 10).ToList();

            return Task<List<Order>>.Factory.StartNew(() => orders);
        }
    }
}

