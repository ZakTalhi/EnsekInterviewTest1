using AccountMeterReading.Data.Data;
using AccountMeterReading.Data.Data.Repos.Contracts;
using AccountMeterReading.Data.Data.Repos.Implementation;
using AccountMeterReading.Data.Data.UnitOfWork;
using AccountMeterReading.Data.Service.Contracts;
using AccountMeterReading.Data.Service.Implementation;
using AccountMeterReading.Data.Utility.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMeterReading.Data.Utility.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            RegisterServicesAndData(services);
            
        }

  
     

        public static void ConfigureDB(this IServiceCollection services, IConfiguration configuration)
        {            
            var ConnectionString = configuration.GetConnectionString("customerMeterDB");
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(ConnectionString));
        }


        public static void AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var ConnectionString = configuration.GetConnectionString("customerMeterDB");
            services.Configure<DatabaseConfigStore>(o =>
            {
                o.DatabaseConnection = ConnectionString;
            });
        }



        private static void RegisterServicesAndData(IServiceCollection services)
        {
            services.AddScoped<ICustomerAccountService, CustomerAccountService>();
            services.AddScoped<ICustomerAccountRepository, CustomerAccountRepository>();

            services.AddScoped<IMeterReaderUploadService, MeterReaderUploadService>();
            services.AddScoped<IMeterReaderUploadRespository, MeterReaderUploadRespository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        

      
    }


    
}
