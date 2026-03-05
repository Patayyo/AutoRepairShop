using AutoRepairShop.Application.Factories;
using AutoRepairShop.Application.Services;
using AutoRepairShop.Domain.Ports;
using AutoRepairShop.Infrastructure.Repositorty;
using AutoRepairShop.Infrastructure.Repository;
using AutoRepairShop.Infrastructure.Repository.Context;
using AutoRepairShop.Web.Configuration;
using AutoRepairShop.Web.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAppConfiguration, AppConfiguration>();

builder.Services.AddDbContext<AutoRepairShopDbContext>((sp, opt) =>
{
    var cfg = sp.GetRequiredService<IAppConfiguration>();
    opt.UseSqlite(cfg.ConnectionString);
});

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ITypeOfWorkRepository, TypeOfWorkRepository>();
builder.Services.AddScoped<ICarWorkHistoryRepository, CarWorkHistoryRepository>();

builder.Services.AddSingleton<GasolineCarFactory>();
builder.Services.AddSingleton<DieselCarFactory>();

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ITypeOfWorkService, TypeOfWorkService>();
builder.Services.AddScoped<ICarWorkHistoryService, CarWorkHistoryService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<LoggingMiddleware>();

app.MapControllers();

app.Run();
