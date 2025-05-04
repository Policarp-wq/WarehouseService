using WarehouseService.Application.DTO.EmployeeInfo;
using WarehouseService.Application.DTO.ItemPresentation;
using WarehouseService.Application.DTO.Location;
using WarehouseService.Application.DTO.WarehouseInfo;
using WarehouseService.Application.DTO.WarehousePresentation;
using WarehouseSevice.Domain.Entities;

namespace WarehouseService.Application.Services
{
    public interface IWarehouseService
    {
        Task<WarehousePresentation> CreateWarehouse(WarehouseInfo info);
        Task<EmployeeInfo?> GetOwner(int warehouseId);
        Task<bool> DeleteWarehouse(int warehouseId);
        Task<bool> CreateItem(ItemCreateInfo createInfo);
        Task<bool> AcceptItem(AcceptShipment shipment);
        Task<bool> ReleaseItem(ReleaseShipment shipment);
        Task<bool> AllocateItem(int itemId, string sector);
        Task<long> GetFullness(int warehouseId);
        Task<bool> SetItemSector(ItemSectorInfo sectorinfo);
    }
}
