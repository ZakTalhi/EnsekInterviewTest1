using AccountMeterReading.Data.Data.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMeterReading.Data.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerAccountRepository CustomerAccountRepository { get; }
        IMeterReaderUploadRespository MeterReaderUploadRespository { get; }
       
        Task<int> CommitAsync();
    }
}
