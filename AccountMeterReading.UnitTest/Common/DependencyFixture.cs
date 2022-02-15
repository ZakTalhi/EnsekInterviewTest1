
using AccountMeterReading.UnitTest.TestData;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AccountMeterReading.UnitTest.Common
{
    public class DependencyFixture : IDisposable
    {
        public DependencyFixture()
        {
            ServiceCollection services = new ServiceCollection();
            //services.AddSingleton(ConfigurationManager.Configuration);
            services.ConfigureServicesForTests();
            //services.AddLogging();
            ServiceProvider = services.BuildServiceProvider();

           TestDataGenerator.Seed();
        }

        public void Dispose()
        {
            TestDataGenerator.Cleanup();
            
        }

        /// <summary>
        /// Access Service provider across all Unit tests
        /// </summary>
        public ServiceProvider ServiceProvider { get; private set; }
    }
}
