using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSevice.Domain.Entities;

namespace WarehouseService.AppHost.ModelsConfigurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            //builder.HasOne(w => w.Owner).WithOne(e => e.Warehouse);
            builder.HasMany(w => w.Employees).WithOne(e => e.Warehouse);
            builder.HasMany(w => w.Items).WithOne(i => i.Warehouse);
        }
    }
}
