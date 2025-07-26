using MassTransit;

namespace TelematicsSystem.Messaging.Abstractions
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public EventPublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public async Task PublishAsync<T>(List<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
        {
            foreach (var domainEvent in domainEvents)
            {
                await _publishEndpoint.Publish((T)domainEvent, cancellationToken);
            }
        }
    }
}
