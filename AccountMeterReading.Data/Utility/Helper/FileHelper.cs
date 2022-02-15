using AccountMeterReading.Data.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AccountMeterReading.Data.Utility.Helper
{
    public static class FileHelper
    {
        public static async Task<string> ReadFile(IFormFile file)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(await reader.ReadLineAsync());
            }
            return result.ToString();
        }

        public static async Task<IList<MeterReading>> ReadMeterReadingCSV(IFormFile file)
        {
            var csv = await ReadFile(file);
            bool firstRow = true;
            IList<MeterReading> meterReadings = new List<MeterReading>();
            foreach (string row in csv.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    if (firstRow)
                    {
                        firstRow = false;
                    }
                    else
                    {
                        try
                        {
                            var cell = row.Split(',');


                            if (cell[2].Trim().Length > 5)
                                continue;


                            meterReadings.Add(new MeterReading
                            {
                                CustomerAccountId = Convert.ToInt32(cell[0]),
                                MeterReadingDate = cell[1].ToDateTime("dd/MM/yyyy HH:mm"),
                                MeterReadValue = cell[2].Trim().PadLeft(5, '0')
                            });
                        }
                        catch 
                        {
                        }
                    }
                }
            }

            return meterReadings;
        }

        public static async Task<IList<CustomerAccount>> ReadCustomerAccountCSV(IFormFile file)
        {
            var csv = await ReadFile(file);
            bool firstRow = true;
            IList<CustomerAccount> accounts = new List<CustomerAccount>();
            foreach (string row in csv.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    if (firstRow)
                    {
                        firstRow = false;
                    }
                    else
                    {


                        var cell = row.Split(',');

                        
                        accounts.Add(new CustomerAccount
                        {
                            AccountId = Convert.ToInt32(cell[0]),
                            FirstName = cell[1].Trim(),
                            LastName = cell[2].Trim()
                    });
                    }
                }
            }

            return accounts;
        }
    }
}
