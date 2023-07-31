using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCorp.Domain.Validations;
using AcmeCorp.Domain.Validations.Order;

namespace AcmeCorp.Domain.Commands.Order
{
    public class UpdateOrderCommand : OrderCommand
    {
        public UpdateOrderCommand(Guid customerId)
        {
            CustomerId = customerId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
