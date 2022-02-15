using AccountMeterReading.Data.Data.Entities;
using AccountMeterReading.Data.Data.UnitOfWork;
using AccountMeterReading.Data.Service.Contracts;
using AccountMeterReading.Data.Utility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMeterReading.Data.Service.Implementation
{
    public class MeterReaderUploadService : IMeterReaderUploadService
    {

        private IUnitOfWork _unitofWork;
        public MeterReaderUploadService(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public Task Delete(MeterReading meterReading)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MeterReading>> GetAll()
        {
            return await _unitofWork.MeterReaderUploadRespository.GetMeterReading();
        }

        public Task<MeterReading> Save(MeterReading meterReading)
        {
            throw new NotImplementedException();
        }

        public async Task<MeterReadingResponse> Save(IList<MeterReading> meterReading)
        {
            var response = new MeterReadingResponse();
             
            foreach (var item in meterReading)
            {
                var existingCustomer = (await _unitofWork.CustomerAccountRepository.GetAllAsync())
                    .Any(o => o.AccountId == item.CustomerAccountId);


                if (!existingCustomer)
                {
                    response.FailedMeterReading.Add(item);
                    continue;
                }

                var existing = (await _unitofWork.MeterReaderUploadRespository.GetAllAsync())
                    .Any(o => o.CustomerAccountId == item.CustomerAccountId && o.MeterReadValue == item.MeterReadValue
                    && (o.MeterReadingDate == item.MeterReadingDate || item.MeterReadingDate<o.MeterReadingDate));

                if (existing)
                {
                    response.FailedMeterReading.Add(item);
                    continue;
                }



                if (item.MeterReadValue.Trim().Length > 5)
                {
                    response.FailedMeterReading.Add(item);
                    continue;
                }

                try
                {
                    await _unitofWork.MeterReaderUploadRespository.AddAsync(item);
                    await _unitofWork.CommitAsync();
                    response.SuccessedMeterReading.Add(item);
                }
                catch (Exception ex)
                {
                    response.FailedMeterReading.Add(item);
                }
            }

            return response;
        }

        public Task Update(MeterReading meterReading)
        {
            throw new NotImplementedException();
        }
    }
}
