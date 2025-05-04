using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Enums;

namespace WarehouseService.Application.Repositories
{
    public interface IWarehouseShipment
    {
        Task<bool> CreateShipment(WarehouseShipment shipment);
        Task<IEnumerable<WarehouseShipment>> GetEmployeesShipments(int employeeId);
        Task<IEnumerable<WarehouseShipment>> GetShipmentsByAction(ShipmentAction action);
        Task<IEnumerable<WarehouseShipment>> GetByDateRange(DateTime startDate, DateTime endDate);
        Task<IEnumerable<WarehouseShipment>> GetWarehouseShipments(int warehouseId);
    }
}
