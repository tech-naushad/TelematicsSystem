using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using VehicleManagement.Domain.Entities;

namespace VehicleManagement.Infrastructure.Persistence.Configurations
{
    public sealed class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");
            builder.HasKey(x => x.VehicleId);
            //set manually (new Guid() in the constructor).
            builder.Property(v => v.VehicleId).ValueGeneratedNever().IsRequired();
          
            builder.Property(x => x.LicensePlate)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(x => x.LicensePlate)
              .IsUnique();

            builder.Property(v => v.VIN)
               .IsRequired()
               .HasMaxLength(17);

            builder.HasIndex(x => x.VIN)
           .IsUnique();

            builder.Property(v => v.Manufacturer)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(v => v.Model)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(v => v.Year)
                   .IsRequired();

            builder.Property(v => v.Type)
                   .IsRequired();
            builder.Property(v => v.Type).HasConversion<string>(); //Will store enum as string

            builder.Property(v => v.Color)
                   .HasMaxLength(20);

            builder.Property(v => v.RegistrationExpiry);

            builder.Property(v => v.DateCreated)
                     .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");

            builder.Property(v => v.CreatedUserId)
           .HasDefaultValue("System");

            builder.Property(v => v.DateUpdated);

            builder.Property(v => v.UpdatedByUserId);
            builder.Property(v => v.Source);
        } 
    }
}
