using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelematicsSystem.Messaging.Contracts;

namespace TelematicsSystem.Messaging.Consumers
{
    public class VehicleCreatedConsumer : IConsumer<VehicleCreatedEvent>
    {
        public VehicleCreatedConsumer()
        {
            
        }
        public async Task Consume(ConsumeContext<VehicleCreatedEvent> context)
        {
            Console.WriteLine($"VehicleCreatedConsumer is called is {context.Message}");
        }
    }
}
