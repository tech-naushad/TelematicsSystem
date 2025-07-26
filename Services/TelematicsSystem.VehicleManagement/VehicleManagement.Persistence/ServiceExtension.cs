using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VehicleManagement.Persistence
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddDbContext<VehicleDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("VehicleDbConnection"))
            );
            return services;
        }
    }
}
