using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VehicleManagement.Infrastructure;

namespace VehicleManagement.Infrastructure.Persistence
{
    public class DbInitializer
    {
        private readonly VehicleDbContext _context;

        public DbInitializer(VehicleDbContext context)
        {
            _context = context;
        }
        public async Task InitialiseAsync()
        {
            if (_context.Database.IsNpgsql())
            {
                await _context.Database.MigrateAsync();
            }
        }

        public async Task SeedDataAsync()
        {
            //if (!await _context.Nationalities.AnyAsync())
            //{
            //    var nationalities = new List<Nationality>();               
            //    nationalities.Add(new Nationality { Name = "United Arab Emirates" } );
            //    nationalities.Add(new Nationality { Name = "United State of America" });
            //    nationalities.Add(new Nationality { Name = "India" });
            //    nationalities.Add(new Nationality { Name = "United Kingdom" });

            //    await _context.Nationalities.AddRangeAsync(nationalities);
            //     _context.SaveChanges();
            //}

        }

    }
}
