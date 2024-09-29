using Restaurants.Infrastructure.Extensions;
using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Seeders;
using Serilog;
using Restaurants.API.Middlewares;
using Restaurants.API.Extensions;
using Restaurants.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentationLayerExtensions(builder.Host);
builder.Services.AddApplicationLayerExtensions();
builder.Services.AddInfrastructureLayerExtensions(builder.Configuration);

var app = builder.Build();
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.Seed();

//apenas para executar o swagger no azure   
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<TimeLoggingMiddleware>();

app.MapSwagger();
app.MapGroup("api/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.MapControllers();

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
//app.UseAuthorization();

app.Run();
