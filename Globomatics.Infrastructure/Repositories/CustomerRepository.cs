using Globomantics.Domain.Models;
using Globomantics.Infrastructure.Data;
using Globomatics.Infrastructure.Interfaces.Repositories;

namespace Globomatics.Infrastructure.Repositories;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(GlobomanticsContext context) : base(context)
    {
    }
}
