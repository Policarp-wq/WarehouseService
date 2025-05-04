using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WarehouseService.Application.DTO.EmployeeInfo;
using WarehouseService.Application.DTO.ItemPresentation;
using WarehouseService.Application.DTO.Location;
using WarehouseService.Application.DTO.WarehouseInfo;
using WarehouseService.Application.DTO.WarehousePresentation;
using WarehouseService.Application.Services;
using WarehouseSevice.Domain.Exceptions;

namespace WarehouseService.AppHost.Middleware.Endpoints
{
    public static class WarehouseEndpoints
    {
        public static IEndpointRouteBuilder MapWarehouseEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("warehouses");

            group.MapPost("create", CreateWarehouse);
            group.MapPost("createItem", CreateItem);
            group.MapPost("accept", AcceptItem);
            group.MapPost("release", ReleaseItem);
            group.MapPost("allocate", AllocateItem);
            group.MapPost("setSector", SetItemSector);
            group.MapGet("owner", GetOwner);
            group.MapGet("fullness", GetFullness);
            group.MapGet("info", GetInfo);
            group.MapDelete("delete", DeleteWarehouse);
            return builder;
        }

        private static async Task<Results<Ok<WarehousePresentation>, BadRequest<string>>> CreateWarehouse(
            IWarehouseService service, [FromBody] WarehouseInfo info)
        {
            var res = await service.CreateWarehouse(info);
            return TypedResults.Ok(res);
        }

        private static async Task<Results<Ok<bool>, BadRequest<string>>> CreateItem(
            IWarehouseService service, [FromBody] ItemCreateInfo info)
        {
            try
            {
                return TypedResults.Ok(await service.CreateItem(info));
            }
            catch (WarehouseOverflowException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }

        private static async Task<Results<Ok<bool>, BadRequest<string>>> AcceptItem(
            IWarehouseService service, [FromBody] AcceptShipment shipment)
        {
            try
            {
                return TypedResults.Ok(await service.AcceptItem(shipment));
            }
            catch (WarehouseOverflowException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }

        private static async Task<Results<Ok<bool>, BadRequest<string>>> ReleaseItem(
            IWarehouseService service, [FromBody] ReleaseShipment shipment)
        {
            try
            {
                return TypedResults.Ok(await service.ReleaseItem(shipment));
            }
            catch (WarehouseOverflowException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }

        private static async Task<Ok<bool>> AllocateItem(
            IWarehouseService service, [FromQuery] int itemId, [FromQuery] string sector)
        {
            return TypedResults.Ok(await service.AllocateItem(itemId, sector));
        }

        private static async Task<Ok<bool>> SetItemSector(
            IWarehouseService service, [FromBody] ItemSectorInfo sectorInfo)
        {
            return TypedResults.Ok(await service.SetItemSector(sectorInfo));
        }

        private static async Task<Results<Ok<EmployeeInfo>, NotFound>> GetOwner(
            IWarehouseService service, [FromQuery] int warehouseId)
        {
            var res = await service.GetOwner(warehouseId);
            return res == null ? TypedResults.NotFound() : TypedResults.Ok(res);
        }

        private static async Task<Ok<long>> GetFullness(
            IWarehouseService service, [FromQuery] int warehouseId)
        {
            return TypedResults.Ok(await service.GetFullness(warehouseId));
        }
        private static async Task<Ok<WarehousePresentation>> GetInfo(
            IWarehouseService service, [FromQuery] int warehouseId)
        {
            return TypedResults.Ok(await service.GetById(warehouseId));
        }

        private static async Task<Ok<bool>> DeleteWarehouse(
            IWarehouseService service, [FromQuery] int warehouseId)
        {
            return TypedResults.Ok(await service.DeleteWarehouse(warehouseId));
        }
    }
}
