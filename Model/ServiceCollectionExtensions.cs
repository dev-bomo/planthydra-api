using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using planthydra_api.DataAccess.Entities;
using planthydra_api.Model.Repositories;

namespace planthydra_api.Model
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataServices(this IServiceCollection services, IHostEnvironment environment)
        {
            services.AddDbContext<Db>(options => options.UseSqlite(environment.GetSqlConnectionString()));
            services.AddScoped<Repo>();
        }
    }
}