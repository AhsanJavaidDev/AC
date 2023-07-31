using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCorp.Application.EventSourcedNormalizers;
using AcmeCorp.Application.ViewModels;

namespace AcmeCorp.Application.Interfaces
{
    public interface IOrderAppService : IDisposable
    {
        void CreateOrder(OrderViewModel orderViewModel);
        IEnumerable<OrderViewModel> GetAll();
        IEnumerable<OrderViewModel> GetAll(int skip, int take);
        OrderViewModel GetById(Guid id);
        void Update(OrderViewModel orderViewModel);
    }
}
