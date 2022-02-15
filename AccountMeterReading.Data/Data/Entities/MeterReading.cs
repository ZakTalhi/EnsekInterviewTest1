using System; 

namespace AccountMeterReading.Data.Data.Entities
{
    public class MeterReading
    {
        public int Id { get; set; }
        public int CustomerAccountId { get; set; }
        public DateTime MeterReadingDate { get; set; }
        public string MeterReadValue { get; set; }

        public CustomerAccount CustomerAccount { get; set; }
    }
}
