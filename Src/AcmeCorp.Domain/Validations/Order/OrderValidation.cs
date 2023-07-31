using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCorp.Domain.Commands;
using AcmeCorp.Domain.Commands.Order;
using FluentValidation;

namespace AcmeCorp.Domain.Validations.Order
{
    public abstract class OrderValidation<T> : AbstractValidator<T> where T : OrderCommand
    {
        protected void ValidateCustomerId()
        {
            RuleFor(c => c.CustomerId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
