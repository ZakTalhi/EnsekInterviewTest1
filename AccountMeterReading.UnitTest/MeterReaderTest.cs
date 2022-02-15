using AccountMeterReading.Data.Data.Entities;
using AccountMeterReading.Data.Service.Contracts;
using AccountMeterReading.UnitTest.Common;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AccountMeterReading.UnitTest
{
    [Collection("Sequential")]
    public class MeterReaderTest : IClassFixture<DependencyFixture>
    {
        private ServiceProvider _serviceProvider;
        public MeterReaderTest(DependencyFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public async Task SAVE_CUSTOMER_ACCOUNTS()
        {
            var customerService = _serviceProvider.GetService<ICustomerAccountService>();
            var data = new List<CustomerAccount>()
            {
                new CustomerAccount
                {
                    AccountId=200,
                    FirstName="Zak",
                    LastName="Talhi"
                },
                new CustomerAccount
                {
                    AccountId=201,
                    FirstName="Zak",
                    LastName="Talhi"
                },
                  new CustomerAccount
                {
                    AccountId=203,
                    FirstName="Zak",
                    LastName="Talhi"
                },
                   new CustomerAccount
                {
                    AccountId=204,
                    FirstName="Zak",
                    LastName="Talhi"
                }
            };

            var accountIds = data.Select(o => o.AccountId).ToArray();
            await customerService.Save(data);
            var record = (await customerService.GetAll())
                .Where(o => accountIds.Contains(o.AccountId)).ToList();           
            Assert.Equal(record.Count, data.Count);
        }

        [Fact]
        public async Task GET_ALL_CUSTOMERS()
        {
            var customerService = _serviceProvider.GetService<ICustomerAccountService>();
            var record = (await customerService.GetAll()).ToList();

            Assert.NotNull(record);
        }

        [Fact]
        public async Task GET_ALL_METER_READINGS()
        {
            var meterReadingService = _serviceProvider.GetService<IMeterReaderUploadService>();
            var record = (await meterReadingService.GetAll()).ToList();

            Assert.NotNull(record);
        }




        [Fact]
        public async Task SAVE_METER_READING()
        {
            var customerService = _serviceProvider.GetService<ICustomerAccountService>();

            var data = new List<CustomerAccount>()
            {
                new CustomerAccount
                {
                    AccountId=100,
                    FirstName="Zak",
                    LastName="Talhi"
                },
                new CustomerAccount
                {
                    AccountId=101,
                    FirstName="Zak1",
                    LastName="Talhi1"
                }
            };
            //seeding some data to verify meter reading response.
            await customerService.Save(data);

            var meterReadingService = _serviceProvider.GetService<IMeterReaderUploadService>();

            var meterReadingData = new List<MeterReading>()
            {
                new MeterReading
                {
                    CustomerAccountId=100,
                    MeterReadingDate = System.DateTime.Now,
                    MeterReadValue="400"
                },
                new MeterReading
                {
                    CustomerAccountId=101,
                    MeterReadingDate = System.DateTime.Now,
                    MeterReadValue="500"
                },
                new MeterReading
                {
                    CustomerAccountId=103,
                    MeterReadingDate = System.DateTime.Now,
                    MeterReadValue="400"
                },
            };

            var responseData = await meterReadingService.Save(meterReadingData);

            Assert.Equal(responseData.SuccessedMeterReading.Count, 2);
            Assert.Equal(responseData.FailedMeterReading.Count, 1);


        }
    }
}
