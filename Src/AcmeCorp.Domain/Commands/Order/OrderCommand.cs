using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCorp.Domain.Core.Commands;

namespace AcmeCorp.Domain.Commands.Order
{
    public abstract class OrderCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid CustomerId { get; protected set; }
    }
}
