using WarehouseService.Application.Repositories;
using WarehouseService.Application.Services;
using WarehouseService.Infrastructure.Repositories;
using WarehouseService.Infrastructure.Services;

namespace WarehouseService.AppHost.DependencyInjections
{
    public static class ConfigureInjectionsExtension
    {
        public static IServiceCollection AddReposInjection(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemWarehouseLocationRepository, ItemWarehouseLocationRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            return services;
        }
        public static IServiceCollection AddServicesInjection(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IWarehouseService, Infrastructure.Services.WarehouseService>();
            services.AddScoped<IWarehouseStorageService, WarehouseStorageService>();
            return services;
        }
    }
}
