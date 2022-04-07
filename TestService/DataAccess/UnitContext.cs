using TestService.DataAccess.Entity;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace TestService.DataAccess
{
    public class UnitContext: DbContext
    {
        public UnitContext(DbContextOptions options) : base(options) { }
        public DbSet<Unit>? Units { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUnit(modelBuilder);
        }
        private static void ConfigureUnit(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>()
                .HasOne(x => x.MainUnit)
                .WithMany(u => u.SubUnits)
                .HasForeignKey(u => u.MainId)
                .IsRequired(false);
            modelBuilder.Entity<Unit>()
                .HasIndex(u => u.Id)
                .IsUnique();
            modelBuilder.Entity<Unit>()
                .Property(u => u.Name)
                .IsRequired();
        }
    }
}
