using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMeterReading.Data.Utility.Model
{
    public class MeterReadingRequest
    {
        public IFormFile MeterReadingFile { get; set; }
    }
}
