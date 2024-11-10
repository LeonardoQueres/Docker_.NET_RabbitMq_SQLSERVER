using Microsoft.EntityFrameworkCore;
using Restaurante_Borders.Entities;

namespace Restaurante_Repositories.DataContext
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Restaurante> Restaurante { get; set; }
    }
}
