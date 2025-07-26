using MassTransit;
using System.Text.Json.Serialization;
using TelematicsSystem.Infrastructure.Configurations;
using TelematicsSystem.Messaging.Consumers;
using VehicleManagement.API;
using VehicleManagement.Application;
using VehicleManagement.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();

    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Vehicle API",
        Version = "v1"
    });
   // c.SchemaFilter<CreateVehicleDtoExampleFilter>();
}

);

//builder.Services.AddInfraServices();
builder.Services.AddCommonServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();

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
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger(c =>
    {
        c.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0;
    });
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vehicle API V1");
    }
    );
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
