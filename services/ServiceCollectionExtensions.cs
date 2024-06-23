using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.repository;
using barberdotnet.model.converter;
using barberdotnet.model.entities;
using barberdotnet.controllers.middleware;

namespace barberdotnet.services
{
public static class ServiceCollectionExtensions
{
    // Its intended use is for removing boilderplate on Program.cs by adding services in one line
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        var serviceType = typeof(ITimeslotService);
        var serviceImplementationType = typeof(TimeslotService);
        var dayService = typeof(IDayService);
        var dayServiceImplementation = typeof(DayService);

        if (serviceType.IsAssignableFrom(serviceImplementationType))
        { 
            services.AddScoped(dayService, dayServiceImplementation);
            services.AddScoped(serviceType, serviceImplementationType);
            services.AddScoped<WeekService>();
            
            services.AddScoped<TStoDTO>();    
            services.AddScoped<DayToDTO>();
            services.AddScoped<TSshortToDTO>();
            services.AddScoped<TSListToDTO>();
            services.AddScoped<TSReservation>();
            
            services.AddScoped<BarberRepo>();
            services.AddScoped<TimeslotRepo>();
            services.AddScoped<DayRepo>();
            services.AddScoped<WeekRepo>();
            

        }

       

        return services;
    }
} 
}