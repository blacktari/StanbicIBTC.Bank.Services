using StanbicIBTC.Bank.Services.Models;

namespace StanbicIBTC.Bank.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(CustomerCreationRequest request);
    }
}
