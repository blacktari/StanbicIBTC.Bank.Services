using StanbicIBTC.Bank.Services.Models;

namespace StanbicIBTC.Bank.Services.DTOs.Request
{
    public class AccountCreationRequest
    {

        // Customer-specific details
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        // Account-specific details
        public AccountType AccountType { get; set; }
        public decimal InitialDepositAmount { get; set; }
        public string PreferredBranch { get; set; }
        public string CurrencyType { get; set; }

        // Legal/Compliance
        public bool HasAgreedToTerms { get; set; }
        public DateTime AgreementDate { get; set; }

        // Source of account creation (for tracking purposes)
        public string AccountCreationSource { get; set; }
    }
}
