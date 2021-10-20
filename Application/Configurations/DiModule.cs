using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance;
using Persistance.Repositories;
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
            services.AddTransient<IIdeaService, IdeaService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddTransient<IIdeaRepository, IdeaRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddDbContext<IdeasDbContext>(x => x.UseSqlServer(connectionString));
            return services;
        }
    }
}
