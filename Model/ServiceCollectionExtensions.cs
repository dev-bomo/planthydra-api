using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using planthydra_api.DataAccess.Entities;
using planthydra_api.Model.Repositories;

namespace planthydra_api.Model
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<Repo>();
        }
    }
}