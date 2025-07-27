
using TelematicsSystem.Abstractions;

namespace VehicleManagement.API
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
        {            
            //services.AddScoped<IEventPublisher, EventPublisher>();
            return services;
        }
    }
}
