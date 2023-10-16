using System;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask
{
	public class OrderService : IOrderService
	{
		public OrderService()
		{
		}

        public Task<Order> GetOrder()
        {
            return null;
        }

        public Task<List<Order>> GetOrders()
        {
            return null;
        }
    }
}

