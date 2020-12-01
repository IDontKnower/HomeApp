using System;
using Dawn;
using HomeApp.WebApi.Contexts.ShoppingList.Models;
using HomeApp.WebApi.Settings;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.WebApi.Contexts.ShoppingList
{
    public class ShoppingListContext: DbContext
    {
        private readonly string _connectionString;

        public ShoppingListContext(DbSettings dbSettings)
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
        }
    }
}