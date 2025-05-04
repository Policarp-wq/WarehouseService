using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Enums;

namespace WarehouseService.Application.DTO.EmployeeInfo
{
    public record PositionUpdateInfo(int EmployeeId, Position Position)
    {
    }
}
