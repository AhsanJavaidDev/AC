using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCorp.Domain.Models;

namespace AcmeCorp.Domain.Specifications
{
    public class OrderFilterPaginatedSpecification : BaseSpecification<Order>
    {
        public OrderFilterPaginatedSpecification(int skip, int take)
            : base(i => true)
        {
            ApplyPaging(skip, take);
        }
    }
}
