using MassTransit;
using MassTransit.Mediator;
using TelematicsSystem.Abstractions;
using TelematicsSystem.Common.Enums;
using TelematicsSystem.Contracts;
using VehicleManagement.Application.Dtos;
using VehicleManagement.Application.Interfaces;
using VehicleManagement.Domain.Entities;
using VehicleManagement.Infrastructure;

namespace VehicleManagement.Application.Services
{
    public class VehicleManagementService : IVehicleManagementService
    {
        private readonly VehicleDbContext _dbContext;
        private readonly IPublishEndpoint _publishEndpoint;
        public VehicleManagementService(VehicleDbContext dbContext, IPublishEndpoint publishEndpoint)
        {
            _dbContext = dbContext;
            _publishEndpoint = publishEndpoint;
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
                RegistrationExpiry = DateTime.SpecifyKind(vehicleDto.RegistrationExpiry.Value, DateTimeKind.Utc),
                Source = vehicleDto.Source
            };

            var @event = new VehicleCreatedEvent
            {
                VehicleId = Guid.NewGuid(),
                LicensePlate = vehicle.LicensePlate,
                VIN = vehicle.VIN,
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,
                Year = vehicle.Year,
                VehicleType = vehicle.Type,
                Color = vehicle.Color,
                RegistrationExpiry = vehicle.RegistrationExpiry,
                RegistrationDate = vehicle.RegistrationUpdated,
                CorrelationId = Guid.NewGuid(),
                Source = vehicle.Source,
                EventCreatedAt = DateTime.UtcNow
            };
           
            _dbContext.Vehicles.Add(vehicle);

            await _dbContext.SaveChangesAsync(cancellationToken);

            await _publishEndpoint.Publish(@event);

           // await _mediator.Publish(@event);
           //var domainEvents = _dbContext.GetDomainEvents();
           //if (domainEvents.Any())
           //{
           //    await _publisher.PublishAsync<VehicleCreatedEvent>(domainEvents);
           //}

            return vehicle.VehicleId;
        }
    }
}
