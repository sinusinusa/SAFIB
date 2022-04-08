using TestService.DataAccess.Entity;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace TestService.DataAccess
{
    public class UnitContext: DbContext
    {
        public UnitContext(DbContextOptions options) : base(options) { }
        public DbSet<Unit>? Units { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUnit(modelBuilder);
        }
        private static void ConfigureUnit(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>()
                .HasMany(x => x.SubUnits)
                .WithOne(u => u.MainUnit)
                .HasForeignKey(u => u.MainId)
                .IsRequired(false);
            modelBuilder.Entity<Unit>()
                .HasIndex(u => u.Id)
                .IsUnique();
            modelBuilder.Entity<Unit>()
                .Property(u => u.Name)
                .IsRequired();
            modelBuilder.Entity<Unit>()
                .Property(u => u.MainId)
                .IsRequired(false);
        }
    }
}
