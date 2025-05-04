using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSevice.Domain.Entities;

namespace WarehouseService.AppHost.ModelsConfigurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasOne(i => i.Warehouse).WithMany(w => w.Items);

        }
    }
}
