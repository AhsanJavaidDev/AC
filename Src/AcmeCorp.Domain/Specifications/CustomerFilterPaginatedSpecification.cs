using AcmeCorp.Domain.Models;

namespace AcmeCorp.Domain.Specifications
{
    public class CustomerFilterPaginatedSpecification : BaseSpecification<Customer>
    {
        public CustomerFilterPaginatedSpecification(int skip, int take)
            : base(i => true)
        {
            ApplyPaging(skip, take);
        }
    }
}
