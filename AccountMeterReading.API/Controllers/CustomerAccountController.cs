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

    public class CustomerAccountController : ControllerBase
    {
        private readonly ICustomerAccountService _customerAccountService;
        private IWebHostEnvironment Environment;
        public CustomerAccountController(ICustomerAccountService customerAccount, IWebHostEnvironment _environment)
        {
            _customerAccountService = customerAccount;
            Environment = _environment;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CustomerAccountRequest customerAccount)
        {
            try
            {
                var accounts = await  FileHelper.ReadCustomerAccountCSV(customerAccount.CustomerAccountFile);
                await _customerAccountService.Save(accounts);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
         
    }
}
