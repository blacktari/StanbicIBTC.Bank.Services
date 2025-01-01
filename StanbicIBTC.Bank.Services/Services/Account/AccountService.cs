using StanbicIBTC.Bank.Services.Data;
using StanbicIBTC.Bank.Services.DTOs.Request;
using StanbicIBTC.Bank.Services.Exceptions;
using StanbicIBTC.Bank.Services.Models;

public class AccountService : IAccountService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AccountService> _logger;

    public AccountService(ApplicationDbContext context, ILogger<AccountService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Account CreateAccount(AccountCreationRequest request)
    {
        try
        {
            // Validate the customer exists
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == request.CustomerId);
            if (customer == null)
            {
                var errorMsg = $"Customer with ID {request.CustomerId} not found.";
                _logger.LogError(errorMsg);
                throw new AccountCreationException(errorMsg, 404); // Not Found
            }

            // Business rule: Customer must be at least 21 years old for Fixed Deposit account
            if (request.AccountType == AccountType.FixedDeposit && customer.DateOfBirth > DateTime.UtcNow.AddYears(-21))
            {
                var errorMsg = "Customer must be at least 21 years old to create a Fixed Deposit account.";
                _logger.LogError(errorMsg);
                throw new AccountCreationException(errorMsg, 400); // Bad Request
            }

            // Create account using data from the request
            var account = new Account
            {
                CustomerId = request.CustomerId,
                AccountType = request.AccountType,
                Balance = 0.00M,  // Set initial balance to 0
                DateOpened = DateTime.UtcNow,
                AccountNumber = GenerateAccountNumber(),
                FullName = request.FullName,
                DateOfBirth = request.DateOfBirth,
                NationalId = request.NationalId,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Address = request.Address,
                PreferredBranch = request.PreferredBranch,
                CurrencyType = request.CurrencyType,
                HasAgreedToTerms = request.HasAgreedToTerms,
                AgreementDate = request.AgreementDate,
                AccountCreationSource = request.AccountCreationSource
            };

            // Add account to the database and save changes
            _context.Accounts.Add(account);
            _context.SaveChanges();

            _logger.LogInformation($"Account created successfully: AccountNumber={account.AccountNumber} for Customer ID={request.CustomerId}");
            return account;
        }
        catch (AccountCreationException ex)
        {
            _logger.LogError(ex, "Account creation failed due to business rule violation.");
            throw; // Re-throw the exception so it can be handled in the controller
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while creating the account.");
            throw new AccountCreationException("An error occurred while creating the account. Please try again later.", 500); // Internal Server Error
        }
    }

    private string GenerateAccountNumber()
    {
        // Generate a secure, unique account number (e.g., random with prefix)
        var random = new Random();
        return "ACC" + random.Next(100000, 999999).ToString();
    }
}
