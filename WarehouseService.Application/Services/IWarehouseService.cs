using WarehouseService.Application.DTO.ItemPresentation;
using WarehouseService.Application.DTO.Location;
using WarehouseService.Application.DTO.WarehousePresentation;
using WarehouseSevice.Domain.Entities;

namespace WarehouseService.Application.Services
{
    public interface IWarehouseService
    {
        Task<Warehouse> CreateWarehouse(WarehouseInfo info);
        Task<Employee?> GetOwner(int warehouseId);
        Task<bool> DeleteWarehouse(int warehouseId);
        Task<bool> UpdateOwner(int ownerId);
        Task<bool> CreateItem(ItemCreateInfo createInfo);
        Task<bool> AcceptItem(AcceptShipment shipment);
        Task<bool> ReleaseItem(ReleaseShipment shipment);
        Task<bool> AllocateItem(int itemId, string sector);
        Task<int> GetSpaceLeft(int warehouseId);
        Task<bool> SetItemSector(ItemSectorInfo sectorinfo);
    }
}
