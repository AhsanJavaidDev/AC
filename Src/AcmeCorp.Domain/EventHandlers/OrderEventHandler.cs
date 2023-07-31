using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AcmeCorp.Domain.Events;
using AcmeCorp.Domain.Events.Order;
using MediatR;

namespace AcmeCorp.Domain.EventHandlers
{
    public class OrderEventHandler :
    INotificationHandler<OrderCreateEvent>,
    INotificationHandler<OrderUpdatedEvent>
    {
        public Task Handle(OrderUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(OrderCreateEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }
    }
}
