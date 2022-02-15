using AccountMeterReading.Data.Data.Entities;
using AccountMeterReading.Data.Data.Repos.Contracts;

namespace AccountMeterReading.Data.Data.Repos.Implementation
{
    public class CustomerAccountRepository : Repository<CustomerAccount, int>, ICustomerAccountRepository
    {
        public CustomerAccountRepository(AppDbContext context) : base(context)
        {
        }
        private AppDbContext AppDbContext => Context as AppDbContext;
    }
}
