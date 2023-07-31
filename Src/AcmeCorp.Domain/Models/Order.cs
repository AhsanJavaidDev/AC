using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCorp.Domain.Core.Models;
using System.Xml.Linq;

namespace AcmeCorp.Domain.Models
{
    public class Order : EntityAudit
    {
        public Order(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }

        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        // ...
    }

}
