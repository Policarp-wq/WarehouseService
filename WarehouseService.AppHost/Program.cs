using Microsoft.EntityFrameworkCore;
using WarehouseService.AppHost.DependencyInjections;
using WarehouseService.AppHost.Middleware;
using WarehouseService.Infrastructure.Context;
using WarehouseSevice.Domain.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbInjection();
builder.Services.AddReposInjection();
builder.Services.AddServicesInjection();
builder.Services.AddRedisInjection();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/weatherforecast", (IDbContext context) =>
{
    throw new LogicException("dsd");
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
