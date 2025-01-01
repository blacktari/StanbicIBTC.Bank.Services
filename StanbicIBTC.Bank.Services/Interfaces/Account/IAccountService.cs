using StanbicIBTC.Bank.Services.DTOs.Request;
using StanbicIBTC.Bank.Services.Models;

public interface IAccountService
{
    Account CreateAccount(AccountCreationRequest request);
}
