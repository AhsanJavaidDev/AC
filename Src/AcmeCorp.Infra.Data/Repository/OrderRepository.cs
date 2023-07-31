using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCorp.Domain.Interfaces;
using AcmeCorp.Domain.Models;
using AcmeCorp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorp.Infra.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public Order GetByCustomerId(Guid customerId)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.CustomerId == customerId);
        }
    }
}
