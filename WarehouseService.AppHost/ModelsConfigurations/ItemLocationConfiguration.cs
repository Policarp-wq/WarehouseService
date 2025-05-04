using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSevice.Domain.Entities;

namespace WarehouseService.AppHost.ModelsConfigurations
{
    public class ItemLocationConfiguration : IEntityTypeConfiguration<ItemWarehouseLocation>
    {
        public void Configure(EntityTypeBuilder<ItemWarehouseLocation> builder)
        {
            builder.HasAlternateKey(x => x.ItemId);
            builder.HasOne(x => x.Item)
                .WithOne()
                .HasForeignKey<ItemWarehouseLocation>(x => x.ItemId);
        }
    }
}
