using System;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
	public class UserService : IUserService
	{
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext)
		{
            this.dbContext = dbContext;
        }

        public Task<User> GetUser()
        {
            var grpOrders = from order in dbContext.Orders.ToList()
                            group order by order.UserId into grp
                            select new { userId = grp.Key, count = grp.Count() };

            var maxOrder = grpOrders.MaxBy(item => item.count);

            User maxUser = dbContext.Users.ToList().Find(item => item.Id == maxOrder.userId);
            
            return Task<User>.Factory.StartNew(() => new User 
            { 
                Id = maxUser.Id, 
                Email = maxUser.Email, 
                Status = maxUser.Status 
            });
        }

        public Task<List<User>> GetUsers()
        {
            List<User> users = dbContext.Users.Where(user => user.Status == UserStatus.Inactive).ToList();

            return Task<List<User>>.Factory.StartNew(() => users);
        }
    }
}

