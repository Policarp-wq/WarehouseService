using Microsoft.EntityFrameworkCore;
using WarehouseService.Infrastructure.Context;

namespace WarehouseService.AppHost.DependencyInjections
{
    public static class DbInjectionExtension
    {
        public static IServiceCollection AddDbInjection(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseNpgsql("Host=localhost;Port=5432;Username=mock;Password=mock");
            });
            services.AddScoped<IDbContext, AppDbContext>();
            return services;
        }
    }
}
