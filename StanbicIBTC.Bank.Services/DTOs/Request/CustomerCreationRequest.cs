namespace StanbicIBTC.Bank.Services.Models
{
    public class CustomerCreationRequest
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PreferredBranch { get; set; }
        public string CurrencyType { get; set; }
    }
}
