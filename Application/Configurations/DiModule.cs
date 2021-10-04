using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configurations
{
    public static class DiModule
    {
        public static IServiceCollection Register(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IdeasDbContext>(x => x.UseSqlServer(connectionString));
            return services;
        }
    }
}
