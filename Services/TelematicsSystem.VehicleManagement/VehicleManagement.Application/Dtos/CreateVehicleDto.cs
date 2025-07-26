using MediatR;
using TelematicsSystem.Messaging.Abstractions;
using TelematicsSystem.Messaging.Contracts;
using VehicleManagement.Domain.Entities;
using VehicleManagement.Domain.Enums;
using VehicleManagement.Infrastructure;

namespace VehicleManagement.Application.Dtos
{
    public class CreateVehicleDto
    {
        public string LicensePlate { get; set; }
        public string VIN { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public VehicleType Type { get; set; }

        public string? Color { get; set; }

        public DateTime? RegistrationExpiry { get; set; }
    }
    
}
