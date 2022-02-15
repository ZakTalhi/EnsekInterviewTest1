using AccountMeterReading.Data.Data;
using AccountMeterReading.Data.Data.UnitOfWork;
using AccountMeterReading.Data.Service.Contracts;
using AccountMeterReading.Data.Service.Implementation;
using AccountMeterReading.UnitTest.TestData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace AccountMeterReading.UnitTest.Common
{
    public static class TestServiceCollectionExtensions
    {
        /// <summary>
        /// Configure services and database connections for Unit tests.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServicesForTests(this IServiceCollection services)
        {
            //services.AddAppSettings(ConfigurationManager.Configuration);
            ConfigureAppDbContext(services);
            RegisterService(services);
        }

        private static void RegisterService(IServiceCollection services)
        {
            RegisterBusinessLogic(services);
            RegisterDataAccess(services);
        }

        private static void RegisterBusinessLogic(IServiceCollection services)
        {
            services.AddScoped < IMeterReaderUploadService, MeterReaderUploadService >();
            services.AddScoped<ICustomerAccountService, CustomerAccountService>();
       
        }

        private static void RegisterDataAccess(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        /// <summary>
        /// Configure data source InMemory or SQL Server.
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureAppDbContext(IServiceCollection services)
        {
            CreateInMemoryStore(services);
        }

        private static void CreateInMemoryStore(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                            options.UseInMemoryDatabase(databaseName: $"MeterReadingDB"));

            var providor = services.BuildServiceProvider();
            TestDataGenerator.Initialize(providor);
        }
    }
}
