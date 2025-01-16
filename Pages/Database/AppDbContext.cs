using Microsoft.EntityFrameworkCore;

namespace ParkingApp.Pages
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Parking> Parking { get; set; }

    }
}
