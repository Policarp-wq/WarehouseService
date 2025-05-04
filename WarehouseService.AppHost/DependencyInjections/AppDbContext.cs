using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WarehouseService.Infrastructure.Context;
using WarehouseSevice.Domain.Entities;

namespace WarehouseService.AppHost.DependencyInjections
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }   
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Warehouse> Warehouses => Set<Warehouse>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<ItemWarehouseLocation> ItemsLocations => Set<ItemWarehouseLocation>();
        public DbSet<WarehouseShipment> ItemsShipments => Set<WarehouseShipment>();

        public Task<int> SaveChangesAsync()
        {
            return SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
