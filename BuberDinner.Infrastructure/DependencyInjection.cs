﻿using BuberDinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure( this IServiceCollection services)
        {
            return services;
        }
    }
}