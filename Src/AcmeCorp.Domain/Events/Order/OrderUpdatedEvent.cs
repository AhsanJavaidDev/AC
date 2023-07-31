using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCorp.Domain.Core.Events;

namespace AcmeCorp.Domain.Events.Order
{
    public class OrderUpdatedEvent : Event
    {
        public OrderUpdatedEvent(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
    }
}
