using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCorp.Domain.Models;

namespace AcmeCorp.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order GetByCustomerId(Guid customerId);
    }
}
