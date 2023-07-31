using System.Linq;
using AcmeCorp.Domain.Interfaces;
using AcmeCorp.Domain.Models;
using AcmeCorp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorp.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public Customer GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
