using StackExchange.Redis;

namespace WarehouseService.AppHost.DependencyInjections
{
    public static class RedisInjectionExtension
    {
        public static IServiceCollection AddRedisInjection(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionMultiplexer>(
                ConnectionMultiplexer.Connect("localhost:6379")
            );
            return services;
        }
    }
}
