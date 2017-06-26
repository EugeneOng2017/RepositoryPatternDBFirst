using DAL;
using Repository.Core;

namespace Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerDbFirstEntities context)
            : base(context)
        {

        }
    }
}
