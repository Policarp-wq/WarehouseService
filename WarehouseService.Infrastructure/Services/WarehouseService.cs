using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseService.Application.DTO.EmployeeInfo;
using WarehouseService.Application.DTO.Employees;
using WarehouseService.Application.DTO.ItemPresentation;
using WarehouseService.Application.DTO.Location;
using WarehouseService.Application.DTO.WarehouseInfo;
using WarehouseService.Application.DTO.WarehousePresentation;
using WarehouseService.Application.Repositories;
using WarehouseService.Application.Services;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Exceptions;

namespace WarehouseService.Infrastructure.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IItemWarehouseLocationRepository _locationRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository,
            IItemRepository itemRepository,
            IItemWarehouseLocationRepository locationRepository,
            IEmployeeRepository employeeRepository)
        {
            _warehouseRepository = warehouseRepository;
            _itemRepository = itemRepository;
            _locationRepository = locationRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> AcceptItem(AcceptShipment shipment)
        {
            if (await IsAvailableToAccept(shipment.WarehouseId))
            {
                await _itemRepository.UpdateWarehouseId(shipment.ItemId, shipment.WarehouseId);
                //--cnt;
                return true;
            }
            throw new WarehouseOverflowException(shipment.WarehouseId);
           
        }

        public async Task<bool> AllocateItem(int itemId, string sector)
        {
            return await _locationRepository.ChangeItemLocation(itemId, sector);
        }

        public async Task<bool> CreateItem(ItemCreateInfo createInfo)
        {
            if(await IsAvailableToAccept(createInfo.WarehouseId))
                return await _itemRepository.CreateItem(createInfo);
            throw new WarehouseOverflowException(createInfo.WarehouseId);
        }

        public async Task<WarehousePresentation> CreateWarehouse(WarehouseInfo info)
        {
            return await _warehouseRepository.CreateWarehouse(info);
        }

        public async Task<bool> DeleteWarehouse(int warehouseId)
        {
            return await _warehouseRepository.DeleteWarehouse(warehouseId);
        }

        public async Task<EmployeeInfo?> GetOwner(int warehouseId)
        {
            var id = await _employeeRepository.GetWarehouseOwner(warehouseId);
            if(id == null) 
                return null;
            return await _employeeRepository.GetById(id.Value);
        }
        private async Task<bool> IsAvailableToAccept(int warehouseId)
        {
            //cache
            var res = await _warehouseRepository.GetById(warehouseId);
            if(res == null)
                return false;
            return await GetFullness(res.WarehouseId) < res.Capacity;
        }

        public Task<int> GetFullness(int warehouseId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ReleaseItem(ReleaseShipment shipment)
        {
            //transaction?
            if(await IsAvailableToAccept(shipment.DestinationWarehouseId))
            {
                await _itemRepository.UpdateWarehouseId(shipment.ItemId, shipment.DestinationWarehouseId);
                //++cnt
            }
            throw new WarehouseOverflowException(shipment.DestinationWarehouseId);
        }

        public async Task<bool> SetItemSector(ItemSectorInfo sectorInfo)
        {
            return await _locationRepository.ChangeItemLocation(sectorInfo.ItemId, sectorInfo.Sector);
        }
    }
}
