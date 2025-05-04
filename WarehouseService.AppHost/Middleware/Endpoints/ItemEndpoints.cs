using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WarehouseService.Application.DTO.ItemPresentation;
using WarehouseService.Application.Services;
using WarehouseSevice.Domain.Enums;
using WarehouseSevice.Domain.Exceptions;

namespace WarehouseService.AppHost.Middleware.Endpoints
{
    public static class ItemEndpoints
    {
        public static IEndpointRouteBuilder MapItemEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("items");

            group.MapGet("getItem", GetItemById);
            group.MapGet("getItemsByCategory", GetItemsByCategory);
            group.MapGet("getItemsByCategoryFromWarehouse", GetItemsByCategoryFromWarehouse);
            group.MapGet("getItemIdsFromWarehouse", GetItemIdsFromWarehouse);
            group.MapPut("updateItemStatus", UpdateItemStatus);

            return builder;
        }

        private static async Task<Results<Ok<ItemPresentation>, NotFound<string>>> GetItemById(
            IItemService service,
            [FromQuery] int itemId)
        {
            try
            {
                var result = await service.GetItemFullInfo(itemId);
                return TypedResults.Ok(result);
            }
            catch (ValidationException ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        private static async Task<Ok<IEnumerable<ItemPresentation>>> GetItemsByCategory(
            IItemService service,
            [FromQuery] ItemCategory category)
        {
            var result = await service.GetItemsByCategory(category);
            return TypedResults.Ok(result);
        }

        private static async Task<Ok<IEnumerable<ItemPresentation>>> GetItemsByCategoryFromWarehouse(
            IItemService service,
            [FromQuery] ItemCategory category,
            [FromQuery] int warehouseId)
        {
            var result = await service.GetItemsByCategoryFromWarehouse(category, warehouseId);
            return TypedResults.Ok(result);
        }

        private static async Task<Ok<IEnumerable<int>>> GetItemIdsFromWarehouse(
            IItemService service,
            [FromQuery] int warehouseId)
        {
            var result = await service.GetItemsFromWarehouse(warehouseId);
            return TypedResults.Ok(result);
        }

        private static async Task<Results<Ok, NotFound>> UpdateItemStatus(
            IItemService service,
            [FromQuery] int itemId,
            [FromQuery] ItemStatus status)
        {
            var result = await service.UpdateStatus(itemId, status);
            return result ? TypedResults.Ok() : TypedResults.NotFound();
        }
    }
}
