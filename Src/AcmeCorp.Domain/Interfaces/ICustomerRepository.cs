using AcmeCorp.Domain.Models;

namespace AcmeCorp.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}
