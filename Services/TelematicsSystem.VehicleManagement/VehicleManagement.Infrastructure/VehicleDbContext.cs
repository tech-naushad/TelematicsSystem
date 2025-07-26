using Microsoft.EntityFrameworkCore;
using TelematicsSystem.Messaging.Abstractions;
using VehicleManagement.Domain.Entities;

namespace VehicleManagement.Infrastructure
{
    public class VehicleDbContext: DbContext, IDomainEventsAccessor
    {        
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options)
            : base(options)
        {}

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(v=>v.Id);
                entity.Property(v=>v.Type).HasConversion<string>(); //Will store enum as string
            });
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Let it just save, and don’t dispatch events here.
            return await base.SaveChangesAsync(cancellationToken);
        }
        public List<IDomainEvent> GetDomainEvents()
        {
            return ChangeTracker
                .Entries<IHasDomainEvents>()
                .SelectMany(e => e.Entity.DomainEvents)
                .ToList();
        }
        public void ClearDomainEvents()
        {
            foreach (var entity in ChangeTracker.Entries<IHasDomainEvents>())
            {
                entity.Entity.ClearDomainEvents();
            }
        }

    }
}
