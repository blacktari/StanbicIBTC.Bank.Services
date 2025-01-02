using StanbicIBTC.Bank.Services.Models;  
using StanbicIBTC.Bank.Services.Data;
using StanbicIBTC.Bank.Services.Services.Interfaces.Customer;

namespace StanbicIBTC.Bank.Services.Services.Implementations.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Customer> CreateCustomerAsync(CustomerCreationRequest request)
        {
            var customer = new Models.Customer 
            {
                FullName = request.FullName,
                DateOfBirth = request.DateOfBirth,
                NationalId = request.NationalId,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Address = request.Address,
                PreferredBranch = request.PreferredBranch,
                CurrencyType = request.CurrencyType
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer; // Return customer of type 'Models.Customer'
        }
    }
}
