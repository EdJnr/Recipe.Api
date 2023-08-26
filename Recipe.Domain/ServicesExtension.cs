using Microsoft.Extensions.DependencyInjection;

namespace Recipe.Domain
{
    public static class ServiceExtensions
    {
        public static IServiceCollection DomainServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
