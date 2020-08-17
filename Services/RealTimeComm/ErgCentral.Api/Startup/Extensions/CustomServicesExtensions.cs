using ErgCentral.Business.Distance;
using ErgCentral.Data.Command;
using ErgCentral.Data.Query;
using Microsoft.Extensions.DependencyInjection;

namespace ErgCentral.Api.Startup.Extensions
{
    public static class CustomServicesExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddDistanceServices();
        }

        private static void AddDistanceServices(this IServiceCollection services)
        {
            services.AddScoped<IDistanceQuery, DistanceQuery>();

            services.AddScoped<IDistanceCommand, DistanceCommand>();

            services.AddScoped<IDistanceService, DistanceService>();
        }
    }
}