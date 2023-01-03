using BuberDinner.Application.Common.Interface.Persistence;
using BuberDinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private List<User> Users = new List<User>();
        public Task Add(User user)
        {
            Users.Add(user);
            return Task.CompletedTask;
        }

        public async  Task<User?> GetByEmail(string Email)
        {
            return Users.SingleOrDefault(ss => ss.Email == Email);
        }
    }
}
