using TelematicsSystem.Abstractions;
using TelematicsSystem.Common.Enums;

namespace TelematicsSystem.Contracts
{
   public class VehicleCreatedEvent  
   {
        public Guid VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public string VIN { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public VehicleType VehicleType { get; set; }
        public string? Color { get; set; }
        public DateTime? RegistrationExpiry { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Guid CorrelationId { get; set; }
        public string? Source { get; set; }
        public DateTime EventCreatedAt { get; set; }
    }
}
