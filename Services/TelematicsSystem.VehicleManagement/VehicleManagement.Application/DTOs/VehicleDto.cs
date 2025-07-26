using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel.DataAnnotations;
using VehicleManagement.Domain.Enums;

namespace VehicleManagement.Application.DTOs
{
    public class VehicleDto
    {
        [SwaggerSchema(Description = "Unique license plate number")]
        [Required]
        [StringLength(100)]
        public string LicensePlate { get; set; }

        [SwaggerSchema(Description = "Manufacturer of the vehicle")]
        [Required]
        [StringLength(100)]
        public string Manufacturer { get; set; }

        [SwaggerSchema(Description = "Vehicle model")]
        [Required]
        [StringLength(100)]
        public string Model { get; set; }

        [SwaggerSchema(Description = "Year of manufacture")]
        [Required]
        [Range(1900, 2100)]
        public int Year { get; set; }

        [SwaggerSchema(Description = "Type of the vehicle")]
        [Required]
        [EnumDataType(typeof(VehicleType))]
        public VehicleType Type { get; set; }

        [SwaggerSchema(Description = "Color of the vehicle")]
        public string? Color { get; set; }

        [SwaggerSchema(Description = "Registration expiry date (ISO string)")]
        public DateTime? RegistrationExpiry { get; set; }
    }
    public class CreateVehicleDtoExampleFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(VehicleDto))
            {
                schema.Example = new OpenApiObject
                {
                    ["LicensePlate"] = new OpenApiString("DEL HB 123-UAE"),
                    ["Manufacturer"] = new OpenApiString("Toyota"),
                    ["Model"] = new OpenApiString("Corolla"),
                    ["Year"] = new OpenApiInteger(2020),
                    ["Type"] = new OpenApiString("Car"),
                    ["Color"] = new OpenApiString("Red"),
                    ["RegistrationExpiry"] = new OpenApiDate(DateTime.UtcNow)
                };
            }
        }
    }
}
