using AccountMeterReading.Data.Data.Entities;
using AccountMeterReading.Data.Utility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMeterReading.Data.Service.Contracts
{
    public interface IMeterReaderUploadService
    {
        Task<MeterReading> Save(MeterReading meterReading);
        Task<MeterReadingResponse> Save(IList<MeterReading> meterReading);
        Task Update(MeterReading meterReading);
        Task Delete(MeterReading meterReading);
        Task<IEnumerable<MeterReading>> GetAll();
    }
}
