using Microsoft.AspNetCore.Http;

namespace AccountMeterReading.Data.Utility.Model
{
    public class CustomerAccountRequest
    {
        public IFormFile CustomerAccountFile { get; set; }
    }
}
