using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AcmeCorp.Application.EventSourcedNormalizers;
using AcmeCorp.Application.Interfaces;
using AcmeCorp.Application.ViewModels;
using AcmeCorp.Domain.Commands;
using AcmeCorp.Domain.Commands.Order;
using AcmeCorp.Domain.Core.Bus;
using AcmeCorp.Domain.Interfaces;
using AcmeCorp.Domain.Specifications;
using AcmeCorp.Infra.Data.Repository.EventSourcing;

namespace AcmeCorp.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IMediatorHandler Bus;

        public OrderAppService(IMapper mapper,
                                  IOrderRepository orderRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            Bus = bus;
        }

        public IEnumerable<OrderViewModel> GetAll()
        {
            return _orderRepository.GetAll().ProjectTo<OrderViewModel>(_mapper.ConfigurationProvider);
        }

        public IEnumerable<OrderViewModel> GetAll(int skip, int take)
        {
            return _orderRepository.GetAll(new OrderFilterPaginatedSpecification(skip, take))
                .ProjectTo<OrderViewModel>(_mapper.ConfigurationProvider);
        }

        public OrderViewModel GetById(Guid id)
        {
            return _mapper.Map<OrderViewModel>(_orderRepository.GetById(id));
        }

        public void CreateOrder(OrderViewModel orderViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewOrderCommand>(orderViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(OrderViewModel orderViewModel)
        {
            var updateCommand = _mapper.Map<UpdateOrderCommand>(orderViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
