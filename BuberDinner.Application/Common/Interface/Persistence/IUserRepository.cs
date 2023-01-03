﻿using BuberDinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Common.Interface.Persistence
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task<User?> GetByEmail(string Email);
    }
}
