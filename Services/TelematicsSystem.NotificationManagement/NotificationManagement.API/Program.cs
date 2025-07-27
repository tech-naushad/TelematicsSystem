using MassTransit;
using NotificationManagement.API.Consumers;
using TelematicsSystem.Common.AppSettings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var rabbitSettings = builder.Configuration
    .GetSection("RabbitMq")
    .Get<RabbitMqSettings>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<VehicleCreatedConsumer>();

    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(rabbitSettings.Host, rabbitSettings.Port, rabbitSettings.VirtualHost, h =>
        {
            h.Username(rabbitSettings.Username);
            h.Password(rabbitSettings.Password);
        });
        Console.WriteLine("RabbitMq is running");

        cfg.ReceiveEndpoint("vehicle-created-queue", e =>
        {
            e.ConfigureConsumer<VehicleCreatedConsumer>(ctx);
        });
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
