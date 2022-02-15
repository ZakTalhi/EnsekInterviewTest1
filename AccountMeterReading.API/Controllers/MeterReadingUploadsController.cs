using AccountMeterReading.Data.Data.Entities;
using AccountMeterReading.Data.Service.Contracts;
using AccountMeterReading.Data.Utility.Helper;
using AccountMeterReading.Data.Utility.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMeterReading.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterReadingUploadsController : ControllerBase
    {
        private readonly IMeterReaderUploadService _meterReaderUploadService;
        private IWebHostEnvironment Environment;
        public MeterReadingUploadsController(IMeterReaderUploadService meterReaderUploadService, IWebHostEnvironment _environment)
        {
            _meterReaderUploadService = meterReaderUploadService;
            Environment = _environment;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromForm] MeterReadingRequest meterReadingRequest)
        {
            try
            {
                var accounts =await FileHelper.ReadMeterReadingCSV(meterReadingRequest.MeterReadingFile);
                var response = await _meterReaderUploadService.Save(accounts);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
