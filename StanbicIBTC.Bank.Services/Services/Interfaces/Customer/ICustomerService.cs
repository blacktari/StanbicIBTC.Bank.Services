using StanbicIBTC.Bank.Services.Models; 

namespace StanbicIBTC.Bank.Services.Services.Interfaces.Customer
{
    public interface ICustomerService
    {
        Task<Models.Customer> CreateCustomerAsync(CustomerCreationRequest request); 
    }
}