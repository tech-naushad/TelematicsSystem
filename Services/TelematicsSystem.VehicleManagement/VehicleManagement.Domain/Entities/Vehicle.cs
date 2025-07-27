using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelematicsSystem.Abstractions;
using TelematicsSystem.Common.Enums;

namespace VehicleManagement.Domain.Entities
{
    public class Vehicle//: BaseEntity
    {
        public Guid VehicleId { get; set; } 
        public string LicensePlate { get; set; }
        public string VIN { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public VehicleType Type { get; set; } = VehicleType.Car;
        public string? Color { get; set; }
        public DateTime? RegistrationExpiry { get; set; }  = DateTime.UtcNow;
        public string CreatedUserId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string? UpdatedByUserId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime RegistrationUpdated { get; set; }
        public string? Source { get; set; }
        public Vehicle()
        {
            VehicleId = Guid.NewGuid();           
        }
    }
}
