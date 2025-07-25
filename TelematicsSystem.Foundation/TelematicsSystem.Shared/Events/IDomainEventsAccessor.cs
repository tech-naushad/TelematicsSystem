using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelematicsSystem.Shared.Events
{
    public interface IDomainEventsAccessor
    {
        List<IDomainEvent> GetDomainEvents();
        void ClearDomainEvents();
    }
}
