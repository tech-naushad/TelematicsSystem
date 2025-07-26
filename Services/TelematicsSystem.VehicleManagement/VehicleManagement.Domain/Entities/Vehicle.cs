using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelematicsSystem.Messaging.Abstractions;
using VehicleManagement.Domain.Enums;

namespace VehicleManagement.Domain.Entities
{
    [Table("Vehicles")]
    public class Vehicle: BaseEntity
    {
        [Key]
        public Guid Id { get; set; } 

        [Required]
        [MaxLength(100)]
        public string LicensePlate { get; set; }

        [Required]
        [MaxLength(100)]
        public string VIN { get; set; }

        [Required]
        [MaxLength(100)]
        public string Manufacturer { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public VehicleType Type { get; set; } = VehicleType.Car;

        public string? Color { get; set; }

        public DateTime? RegistrationExpiry { get; set; }  = DateTime.UtcNow;

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public Vehicle()
        {
            Id = Guid.NewGuid();           
        }
    }
}
