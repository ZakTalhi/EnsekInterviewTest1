using AccountMeterReading.Data.Data.Repos.Contracts;
using AccountMeterReading.Data.Data.Repos.Implementation;
using System.Threading.Tasks;

namespace AccountMeterReading.Data.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private CustomerAccountRepository _customerAccountRepository;
        private MeterReaderUploadRespository _meterReaderUploadRespository;
        
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public ICustomerAccountRepository CustomerAccountRepository => _customerAccountRepository ?? new CustomerAccountRepository(_context);
        public IMeterReaderUploadRespository MeterReaderUploadRespository=> _meterReaderUploadRespository?? new MeterReaderUploadRespository(_context);

       
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
