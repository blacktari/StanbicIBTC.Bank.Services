using System;
using System.Threading.Tasks;

namespace StanbicIBTC.Bank.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<PagedResult<TransactionDTO>> GetTransactionsAsync(TransactionRequest request);
        Task<TransactionDTO> GetTransactionByIdAsync(Guid transactionId);
        Task<Transaction> CreateTransactionAsync(Transaction transaction); // Added CreateTransactionAsync method
    }
}
