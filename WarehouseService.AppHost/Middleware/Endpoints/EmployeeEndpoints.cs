using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WarehouseService.Application.DTO.EmployeeInfo;
using WarehouseService.Application.DTO.Employees;
using WarehouseService.Application.Services;
using WarehouseSevice.Domain.Exceptions;

namespace WarehouseService.AppHost.Middleware.Endpoints
{
    public static class EmployeeEndpoints
    {
        public static IEndpointRouteBuilder MapEmployeeEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("items");

            group.MapPost("create", CreateEmployee);
            group.MapPut("updatePosition", UpdatePosition);
            group.MapPut("updateWarehouse", UpdateWarehouseWork);
            return builder;
        }

        private static async Task<Results<Ok<EmployeePresentation>, BadRequest<string>>> CreateEmployee(
            IEmployeeService service,
            [FromBody] EmployeeInfo info)
        {
            try
            {
                var employee = await service.CreateEmployee(info);
                return TypedResults.Ok(employee);
            }
            catch (LogicException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }

        private static async Task<Results<Ok, NotFound, BadRequest<string>>> UpdatePosition(
            IEmployeeService service,
            [FromBody] PositionUpdateInfo info)
        {
            try
            {
                var result = await service.UpdatePosition(info);
                if (!result)
                    return TypedResults.NotFound();
                return TypedResults.Ok();
            }
            catch (LogicException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }

        private static async Task<Results<Ok, NotFound, BadRequest<string>>> UpdateWarehouseWork(
            IEmployeeService service,
            [FromBody] WarehouseWorkUpdateInfo info)
        {
            try
            {
                var result = await service.UpdateWarehouseWork(info);
                if (!result)
                    return TypedResults.NotFound();
                return TypedResults.Ok();
            }
            catch (LogicException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }
    }
}
