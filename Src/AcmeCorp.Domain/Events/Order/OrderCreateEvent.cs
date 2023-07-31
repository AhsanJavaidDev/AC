using System;
using AcmeCorp.Domain.Core.Events;

namespace AcmeCorp.Domain.Events.Order
{
    public class OrderCreateEvent : Event
    {
        public OrderCreateEvent(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
    }
}
