using Microsoft.Extensions.DependencyInjection;
using MyShuttle.Data;

namespace MyShuttle.Web.AppBuilderExtensions
{
    public static class DependenciesExtensions
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyShuttleContext>();
            services.AddScoped<ICarrierRepository, CarrierRepository>();
            return services;
        }
    }
}
