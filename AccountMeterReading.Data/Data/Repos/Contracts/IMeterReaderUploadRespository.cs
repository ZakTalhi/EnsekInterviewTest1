using AccountMeterReading.Data.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMeterReading.Data.Data.Repos.Contracts
{
    public interface IMeterReaderUploadRespository : IRepository<MeterReading, int>
    {
        Task<IEnumerable<MeterReading>> GetMeterReading();
    }
}
