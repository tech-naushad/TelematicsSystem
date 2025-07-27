using MassTransit;
using TelematicsSystem.Contracts;

namespace NotificationManagement.API.Consumers
{
    public class VehicleCreatedConsumer : IConsumer<VehicleCreatedEvent>
    {
        public VehicleCreatedConsumer()
        {

        }
        public async Task Consume(ConsumeContext<VehicleCreatedEvent> context)
        {
            Console.WriteLine($"VehicleCreatedConsumer is called is {context.Message}");
            await Task.CompletedTask;
        }
    }
}
