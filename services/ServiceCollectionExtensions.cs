using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.repository;
using barberdotnet.model.converter;

namespace barberdotnet.services
{
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        var serviceType = typeof(ITimeslotService);
        var serviceImplementationType = typeof(TimeslotService);

        if (serviceType.IsAssignableFrom(serviceImplementationType))
        {
            services.AddScoped(serviceType, serviceImplementationType);
            services.AddScoped<TStoDTO>();
            services.AddScoped<TimeslotRepo>();
        }

        // Repeat for other services

        return services;
    }
} 
}