using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelematicsSystem.Shared.Events;

namespace TelematicsSystem.Infrastructure.Messaging
{
    public interface IMessageDispatcher
    {
        Task DispatchAsync<T>(List<IDomainEvent> domainEvents, CancellationToken cancellationToken = default);
    }
    public class MessageDispatcher: IMessageDispatcher
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public MessageDispatcher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public async Task DispatchAsync<T>(List<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
        {
            foreach (var domainEvent in domainEvents)
            {
                await _publishEndpoint.Publish((T)domainEvent, cancellationToken);
            }
        }
    }
}
