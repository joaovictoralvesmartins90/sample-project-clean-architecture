using Restaurants.Infrastructure.Extensions;
using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Seeders;
using Serilog;
using Serilog.Events;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrasctructure(builder.Configuration);
builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
        .WriteTo.Console();
});
var app = builder.Build();
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.Seed();

app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
