using Microsoft.AspNetCore.Hosting.Builder;
using spaceWeather.Entities.Models;
using spaceWeather.Repositories.Contracts;
using spaceWeather.Repositories.EFCore;
using spaceWeather.Services;
using spaceWeather.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICelestialBodyRepository, CelestialBodyRepository>();
builder.Services.AddScoped<ICelestialBodyService,CelestialBodyManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
