using Microsoft.EntityFrameworkCore;
namespace dailyphongve.Models
{
    public class dailyphongveDbContext : DbContext
    {
        public dailyphongveDbContext(DbContextOptions<dailyphongveDbContext> options)
            : base(options) { }
        public DbSet<ve> ves { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}