using AccountMeterReading.Data.Data.Entities;
using AccountMeterReading.Data.Data.UnitOfWork;
using AccountMeterReading.Data.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMeterReading.Data.Service.Implementation
{
    public class CustomerAccountService : ICustomerAccountService
    {
        private IUnitOfWork _unitofWork;
        public CustomerAccountService(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task Delete(CustomerAccount customerAccount)
        {
            _unitofWork.CustomerAccountRepository.Remove(customerAccount);
            await _unitofWork.CommitAsync();
        }

        public async Task<IEnumerable<CustomerAccount>> GetAll()
        {
            return await _unitofWork.CustomerAccountRepository.GetAllAsync();
        }

        public async Task<CustomerAccount> Save(CustomerAccount customerAccount)
        {
            await _unitofWork.CustomerAccountRepository.AddAsync(customerAccount);
            await _unitofWork.CommitAsync();
            return customerAccount;
        }

        public async Task<IList<CustomerAccount>> Save(IList<CustomerAccount> customerAccount)
        {
            await _unitofWork.CustomerAccountRepository.AddRangeAsync(customerAccount);
            await _unitofWork.CommitAsync();
            return customerAccount;
        }

        public async Task Update(CustomerAccount customerAccount)
        {
            var customer = await _unitofWork.CustomerAccountRepository.GetByIdAsync(customerAccount.AccountId);
            customer.FirstName = customer.FirstName;
            customer.LastName = customer.LastName;
            _unitofWork.CustomerAccountRepository.Update(customer);
            await _unitofWork.CommitAsync();
        }
    }
}
