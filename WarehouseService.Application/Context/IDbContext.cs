using Microsoft.EntityFrameworkCore;
using WarehouseSevice.Domain.Entities;

namespace WarehouseService.Infrastructure.Context
{
    public interface IDbContext
    {
        public DbSet<Employee> Employees { get; }
        public DbSet<Warehouse> Warehouses { get; }
        public DbSet<Item> Items { get; }
        public DbSet<ItemWarehouseLocation> ItemsLocations { get; }
        public DbSet<WarehouseShipment> ItemsShipments { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync();
    }
}

