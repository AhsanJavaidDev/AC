using System;
using System.Collections.Generic;
using AcmeCorp.Domain.Core.Events;

namespace AcmeCorp.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
