using Recipe.Api.Middlewares;
using System.Reflection;

namespace Recipe.Api
{
    public static class ServicesExtension
    {
        public static IServiceCollection ApiServices(this IServiceCollection services)
        {
            services.AddLogging();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<GlobalErrorHandlerMiddleware>();

            return services;
        }
    }
}
