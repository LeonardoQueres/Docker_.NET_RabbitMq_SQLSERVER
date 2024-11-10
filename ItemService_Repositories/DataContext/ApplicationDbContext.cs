using ItemService_Borders.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItemService_Repositories.DataContext
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Restaurante> Restaurante { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
