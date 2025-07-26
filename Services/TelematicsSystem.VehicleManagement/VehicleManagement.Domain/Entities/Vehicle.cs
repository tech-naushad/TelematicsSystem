using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelematicsSystem.Messaging.Abstractions;
using VehicleManagement.Domain.Enums;

namespace VehicleManagement.Domain.Entities
{
    public class Vehicle: BaseEntity
    {
        public Guid Id { get; set; } 
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
        public DateTime? DateUpdated { get; set; }
        public string? UpdatedByUserId { get; set; }
        public Vehicle()
        {
            Id = Guid.NewGuid();           
        }
    }
}
