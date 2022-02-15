

using System.Collections.Generic;

namespace AccountMeterReading.Data.Data.Entities
{
    public class CustomerAccount
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<MeterReading> MeterReading { get; set; }
    }
}
