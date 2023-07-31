using AutoMapper;
using AcmeCorp.Application.ViewModels;
using AcmeCorp.Domain.Commands;
using AcmeCorp.Domain.Commands.Order;

namespace AcmeCorp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
                .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));

            CreateMap<OrderViewModel, RegisterNewOrderCommand>()
                .ConstructUsing(c => new RegisterNewOrderCommand(c.CustomerId));
            CreateMap<OrderViewModel, UpdateOrderCommand>()
                .ConstructUsing(c => new UpdateOrderCommand(c.CustomerId));
        }
    }
}
