using AutoMapper;
using AcmeCorp.Application.ViewModels;
using AcmeCorp.Domain.Models;

namespace AcmeCorp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Order, OrderViewModel>();
        }
    }
}
