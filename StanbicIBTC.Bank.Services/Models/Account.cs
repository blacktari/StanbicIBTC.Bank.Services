using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StanbicIBTC.Bank.Services.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public AccountType AccountType { get; set; }  // Enum for account type

        [Required]
        public decimal Balance { get; set; }

        [Required]
        public DateTime DateOpened { get; set; }

        // Foreign Key to Customer
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public int CustomerId { get; set; }  // Links account to customer profile

        // The additional fields based on AccountCreationRequest
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PreferredBranch { get; set; }
        public string CurrencyType { get; set; }
        public bool HasAgreedToTerms { get; set; }
        public DateTime AgreementDate { get; set; }
        public string AccountCreationSource { get; set; }
    }
}
