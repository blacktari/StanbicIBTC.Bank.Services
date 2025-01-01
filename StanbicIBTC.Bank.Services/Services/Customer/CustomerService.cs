using StanbicIBTC.Bank.Services.Interfaces;
using StanbicIBTC.Bank.Services.Models;
using StanbicIBTC.Bank.Services.Data;

namespace StanbicIBTC.Bank.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateCustomerAsync(CustomerCreationRequest request)
        {
            var customer = new Customer
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

            return customer;
        }
    }
}
