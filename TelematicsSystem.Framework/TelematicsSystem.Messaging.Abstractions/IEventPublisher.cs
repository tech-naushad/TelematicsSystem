using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelematicsSystem.Messaging.Abstractions
{
    public interface IEventPublisher
    {        
        Task PublishAsync<T>(List<IDomainEvent> domainEvents, CancellationToken cancellationToken = default);
    }
}
 
