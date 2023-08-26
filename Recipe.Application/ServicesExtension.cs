using Microsoft.Extensions.DependencyInjection;
using Recipe.Application.Interfaces.Services;
using Recipe.Application.Services;

namespace Recipe.Application
{
    public static class ServicesExtension
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDifficultyLevels, DifficultyLevelsService>();
            return services;
        }
    }
}
