using TelematicsSystem.Messaging.Abstractions;

namespace TelematicsSystem.Messaging.Contracts
{
    public record VehicleCreatedEvent(
     Guid Id,
     string LicensePlate,
     string Manufacturer,
     string Model,
     int Year,
     string VehicleType,
     string? Color,
     DateTime? RegistrationExpiry,
     DateTime DateCreated
 ): IDomainEvent;
}
