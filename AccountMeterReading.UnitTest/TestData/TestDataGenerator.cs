using AccountMeterReading.Data.Data;
using AccountMeterReading.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;


namespace AccountMeterReading.UnitTest.TestData
{
    public class TestDataGenerator
    {
        private static IServiceProvider _serviceProvider = null;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static void Seed()
        {
            using (var context = new AppDbContext(_serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Create customer accounts 
                SeedCustomerAccount(context);
                SeedMeterReading(context);
                context.SaveChanges();
            }
        }

        public static void Cleanup()
        {
            using (var context = new AppDbContext(_serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {

                context.CustomerAccount.RemoveRange(context.CustomerAccount);
                context.MeterReading.RemoveRange(context.MeterReading);
                context.SaveChanges();
            }
        }

    
        private static void SeedCustomerAccount(AppDbContext context)
        {
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

            context.CustomerAccount.AddRange(data);
        }


        private static void SeedMeterReading(AppDbContext context)
        {
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
              
            };

            context.MeterReading.AddRange(meterReadingData);
        }


    }
}
