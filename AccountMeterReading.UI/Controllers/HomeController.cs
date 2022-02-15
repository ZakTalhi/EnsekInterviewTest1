using AccountMeterReading.Data.Service.Contracts;
using AccountMeterReading.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMeterReading.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMeterReaderUploadService _meterReaderUploadService;
        public HomeController(ILogger<HomeController> logger, IMeterReaderUploadService meterReaderUploadService)
        {
            _logger = logger;
            _meterReaderUploadService = meterReaderUploadService;
        }

        public async Task<IActionResult> Index()
        {
            try
            { 
                var dataReading = (await _meterReaderUploadService.GetAll()).ToList();
                return View(dataReading);
            }
            catch (Exception ex)
            {
                return View(null);
            }
        }

         
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
