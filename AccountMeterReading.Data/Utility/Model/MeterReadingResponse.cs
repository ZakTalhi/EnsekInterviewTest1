using AccountMeterReading.Data.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMeterReading.Data.Utility.Model
{
    public class MeterReadingResponse
    {
        public IList<MeterReading> SuccessedMeterReading { get; set; }
        public IList<MeterReading> FailedMeterReading { get; set; }

        public MeterReadingResponse()
        {
            SuccessedMeterReading = new List<MeterReading>();
            FailedMeterReading = new List<MeterReading>();
        }

    }

}
