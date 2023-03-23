using Locations.Models;
using Microsoft.EntityFrameworkCore;

namespace Locations.Persistence
{
    public class LocationDbContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }

        public LocationDbContext(DbContextOptions<LocationDbContext> options) : base(options)
        {
            
        }
    }
}
