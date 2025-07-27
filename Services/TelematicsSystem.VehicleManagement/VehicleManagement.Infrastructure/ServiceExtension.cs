using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VehicleManagement.Infrastructure.Persistence;

namespace VehicleManagement.Infrastructure
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
          
            services.AddScoped<DbInitializer>();
            return services;
        }
    }
}
