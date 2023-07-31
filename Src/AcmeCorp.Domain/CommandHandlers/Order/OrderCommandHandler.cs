using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AcmeCorp.Domain.Commands;
using AcmeCorp.Domain.Commands.Order;
using AcmeCorp.Domain.Core.Bus;
using AcmeCorp.Domain.Core.Notifications;
using AcmeCorp.Domain.Events;
using AcmeCorp.Domain.Events.Order;
using AcmeCorp.Domain.Interfaces;
using AcmeCorp.Domain.Models;
using MediatR;

namespace AcmeCorp.Domain.CommandHandlers.Order
{
    public class OrderCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewOrderCommand, bool>,
    IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMediatorHandler Bus;

        public OrderCommandHandler(IOrderRepository orderRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _orderRepository = orderRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewOrderCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var order = new AcmeCorp.Domain.Models.Order(Guid.NewGuid(), message.CustomerId);

            if (_orderRepository.GetByCustomerId(order.CustomerId) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The order e-mail has already been taken."));
                return Task.FromResult(false);
            }

            _orderRepository.Add(order);

            if (Commit())
            {
                Bus.RaiseEvent(new OrderCreateEvent(order.Id, order.CustomerId));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateOrderCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var order = new AcmeCorp.Domain.Models.Order(message.Id, message.CustomerId);
            var existingOrder = _orderRepository.GetByCustomerId(order.CustomerId);

            if (existingOrder != null && existingOrder.Id != order.Id)
            {
                if (!existingOrder.Equals(order))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The order e-mail has already been taken."));
                    return Task.FromResult(false);
                }
            }

            _orderRepository.Update(order);

            if (Commit())
            {
                Bus.RaiseEvent(new OrderUpdatedEvent(order.Id, order.CustomerId));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _orderRepository.Dispose();
        }
    }
}
