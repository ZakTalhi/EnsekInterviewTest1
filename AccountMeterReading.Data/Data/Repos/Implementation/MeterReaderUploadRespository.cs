using AccountMeterReading.Data.Data.Entities;
using AccountMeterReading.Data.Data.Repos.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMeterReading.Data.Data.Repos.Implementation
{
    public class MeterReaderUploadRespository : Repository<MeterReading, int>, IMeterReaderUploadRespository
    {
        public MeterReaderUploadRespository(AppDbContext context) : base(context)
        {
        }
        private AppDbContext AppDbContext => Context as AppDbContext;

        public async Task<IEnumerable<MeterReading>> GetMeterReading()
        {
            var meterReading = await AppDbContext.MeterReading
                       .Include(e => e.CustomerAccount).ToListAsync();

            return meterReading;
        }
    }
}
