namespace WarehouseService.AppHost.Middleware.Endpoints
{
    public static class MapEndpoints
    {
        public static IEndpointRouteBuilder MapCustomEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapWarehouseEndpoints();
            builder.MapItemEndpoints();
            builder.MapEmployeeEndpoints();
            return builder;
        }
    }
}
