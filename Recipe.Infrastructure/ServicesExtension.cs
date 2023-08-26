using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Recipe.Application.Interfaces;
using Recipe.Infrastructure.Persistence;
using Recipe.Infrastructure.Persistence.Contexts;

namespace Recipe.Infrastructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection InfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ApplicationDatabaseContext>(opt=> opt.UseInMemoryDatabase("Recipes"));
            return services;
        }
    }
}
