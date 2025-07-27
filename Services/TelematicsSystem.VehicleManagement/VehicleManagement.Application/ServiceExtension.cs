using Microsoft.Extensions.DependencyInjection;
using VehicleManagement.Application.Interfaces;
using VehicleManagement.Application.Services;

namespace VehicleManagement.Application
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            //services.AddMediatR(cfg =>
            //{
            //    cfg.RegisterServicesFromAssemblyContaining<VehicleCreatedEventHandler>();
            //});
            services.AddScoped<IVehicleManagementService, VehicleManagementService>();
            return services;
        }
    }
}
