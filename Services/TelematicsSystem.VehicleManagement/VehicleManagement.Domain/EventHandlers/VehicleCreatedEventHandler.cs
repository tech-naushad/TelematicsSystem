using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelematicsSystem.Contracts;

namespace VehicleManagement.Domain.EventHandlers
{
    //public class VehicleCreatedEventHandler : INotificationHandler<VehicleCreatedEvent>
    //{
    //    private readonly IPublishEndpoint _publishEndpoint;

    //    public VehicleCreatedEventHandler(IPublishEndpoint publishEndpoint)
    //    {
    //        _publishEndpoint = publishEndpoint;
    //    }

    //    public async Task Handle(VehicleCreatedEvent @event, CancellationToken cancellationToken)
    //    {

    //        //var evt = new VehicleCreatedEvent
    //        //    v.Id,
    //        //    v.LicensePlate,
    //        //    v.VIN,
    //        //    v.Manufacturer,
    //        //    v.Model,
    //        //    v.Year,
    //        //    v.VehicleType,
    //        //    v.Color,
    //        //    v.RegistrationExpiry,
    //        //    v.CreatedAt,
    //        //    Guid.NewGuid()
    //        //);

    //        await _publishEndpoint.Publish(@event);
    //    }
    //}
}
