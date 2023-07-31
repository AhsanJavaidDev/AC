using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCorp.Domain.Commands;
using AcmeCorp.Domain.Commands.Order;

namespace AcmeCorp.Domain.Validations.Order
{
    public class RegisterNewOrderCommandValidation : OrderValidation<RegisterNewOrderCommand>
    {
        public RegisterNewOrderCommandValidation()
        {
            ValidateId();
            ValidateCustomerId();
        }
    }
}
