using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace AccountMeterReading.UnitTest
{
    public class ConfigurationManager
    {
        private static IConfiguration _config;

        //public static IConfiguration Configuration
        //{
        //    get
        //    {
        //        if (_config == null)
        //        {
        //            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json");
        //            _config = builder.Build();
        //        }

        //        return _config;
        //    }
        //}
    }
}
