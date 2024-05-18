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
        var dayService = typeof(IDayService);
        var dayServiceImplementation = typeof(DayService);

        if (serviceType.IsAssignableFrom(serviceImplementationType))
        {
            services.AddScoped(serviceType, serviceImplementationType);
            services.AddScoped<TStoDTO>();
            services.AddScoped<TimeslotRepo>();
            services.AddScoped<TSReservation>();
            services.AddScoped<DayRepo>();
            services.AddScoped(dayService, dayServiceImplementation);
            
        }

       

        return services;
    }
} 
}