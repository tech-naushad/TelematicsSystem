using MediatR;
using TelematicsSystem.Abstractions;
using TelematicsSystem.Common.Enums;
using TelematicsSystem.Contracts;
using VehicleManagement.Domain.Entities;
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
        public string? Source { get; set; }
        public DateTime? RegistrationExpiry { get; set; }
    }
    
}
