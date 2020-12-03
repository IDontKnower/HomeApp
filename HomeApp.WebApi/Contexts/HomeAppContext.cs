using System;
using Dawn;
using HomeApp.WebApi.Contexts.ShoppingList;
using HomeApp.WebApi.Settings;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.WebApi.Contexts
{
    public class HomeAppContext: DbContext
    {
        private readonly string _connectionString;

        public HomeAppContext(DbSettings dbSettings)
        {
            Guard.Argument(dbSettings, nameof(dbSettings)).NotNull();
            _connectionString = dbSettings.ToString();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connectionString,
                    new MySqlServerVersion(new Version(8, 0, 22)))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired();
                entity.Property(e => e.Description)
                    .HasColumnType("text");
                entity.Property(e => e.Amount)
                    .IsRequired();
                entity.Property(e => e.IsBought)
                    .IsRequired();
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired();
            });
        }
    }
}