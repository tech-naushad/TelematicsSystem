using TelematicsSystem.Messaging.Abstractions;
using TelematicsSystem.Messaging.Contracts;
using VehicleManagement.Application.Dtos;
using VehicleManagement.Application.Interfaces;
using VehicleManagement.Domain.Entities;
using VehicleManagement.Infrastructure;

namespace VehicleManagement.Application.Services
{
    public class VehicleManagementService : IVehicleManagementService
    {
        private readonly IEventPublisher _publisher;
        private readonly VehicleDbContext _dbContext;
        public VehicleManagementService(VehicleDbContext dbContext, IEventPublisher publisher)
        {
            _dbContext = dbContext;
            _publisher = publisher;
        }
        public async Task<Guid> RegisterVehicleAsync(CreateVehicleDto vehicleDto, CancellationToken cancellationToken = default)
        {
            var vehicle = new Vehicle
            {
                LicensePlate = vehicleDto.LicensePlate,
                VIN = vehicleDto.VIN,
                Manufacturer = vehicleDto.Manufacturer,
                Model = vehicleDto.Model,
                Year = vehicleDto.Year,
                Type = vehicleDto.Type,
                Color = vehicleDto.Color,
                RegistrationExpiry = DateTime.SpecifyKind(vehicleDto.RegistrationExpiry.Value, DateTimeKind.Utc)
            };

            vehicle.AddDomainEvent(new VehicleCreatedEvent
           (
                vehicle.Id,
                vehicle.LicensePlate,
                vehicle.VIN,
                vehicle.Manufacturer,
                vehicle.Model,
               vehicle.Year,
               vehicle.Type.ToString(),
               vehicle.Color,
               vehicle.RegistrationExpiry,
               vehicle.DateCreated
           ));

            _dbContext.Vehicles.Add(vehicle);

            await _dbContext.SaveChangesAsync(cancellationToken);


            var domainEvents = _dbContext.GetDomainEvents();
            if (domainEvents.Any())
            {
                await _publisher.PublishAsync<VehicleCreatedEvent>(domainEvents);
            }

            return vehicle.Id;
        }
    }
}
