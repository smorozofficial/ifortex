using System;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask
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
            User usr = new User { Id = 1, Email = "user1@gmail.com", Status = UserStatus.Active };

            return Task<User>.Factory.StartNew(() => usr);
        }

        public Task<List<User>> GetUsers()
        {
            User usr = new User { Id = 1, Email = "user1@gmail.com", Status = UserStatus.Active };
            List<User> users = this.dbContext.Users.ToList();

            
            return Task<List<User>>.Factory.StartNew(() => users);
        }
    }
}

