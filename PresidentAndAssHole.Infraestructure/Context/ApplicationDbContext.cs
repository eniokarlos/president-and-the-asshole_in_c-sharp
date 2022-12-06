using Microsoft.EntityFrameworkCore;
using presidentAndAssHole.Domain.Entity;

namespace PresidentAndAssHole.Infraestructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        public DbSet<Card> Cards { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseInMemoryDatabase("base");

    }
}