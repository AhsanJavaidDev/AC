using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCorp.Domain.Commands.Order;

namespace AcmeCorp.Domain.Validations.Order
{
    public class UpdateOrderCommandValidation : OrderValidation<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidation()
        {
            ValidateId();
            ValidateCustomerId();
        }
    }
}
