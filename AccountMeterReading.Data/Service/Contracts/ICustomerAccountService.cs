using AccountMeterReading.Data.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountMeterReading.Data.Service.Contracts
{
    public interface ICustomerAccountService
    {
       
        Task<CustomerAccount> Save(CustomerAccount customerAccount);
        Task<IList<CustomerAccount>> Save(IList<CustomerAccount> customerAccount);
        Task Update(CustomerAccount customerAccount);
        Task Delete(CustomerAccount customerAccount);
        Task<IEnumerable<CustomerAccount>> GetAll(); 

    }
}
