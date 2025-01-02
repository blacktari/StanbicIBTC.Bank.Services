using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StanbicIBTC.Bank.Services.Data;
using StanbicIBTC.Bank.Services.Interfaces;
using StanbicIBTC.Bank.Services.Models;

public class TransactionService : ITransactionService
{
    private readonly ApplicationDbContext _context;

    public TransactionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<TransactionDTO>> GetTransactionsAsync(TransactionRequest request)
    {
        var query = _context.Transactions.AsQueryable();

        query = query.Where(t => t.AccountNumber == request.AccountNumber);

        if (request.StartDate.HasValue)
            query = query.Where(t => t.TransactionDate >= request.StartDate.Value);

        if (request.EndDate.HasValue)
            query = query.Where(t => t.TransactionDate <= request.EndDate.Value);

        if (!string.IsNullOrEmpty(request.Status))
            query = query.Where(t => t.Status == request.Status);

        if (!string.IsNullOrEmpty(request.Channel))
            query = query.Where(t => t.Channel == request.Channel);

        var totalRecords = await query.CountAsync();

        var transactions = await query
            .OrderByDescending(t => t.TransactionDate)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(t => new TransactionDTO
            {
                TransactionId = t.Id.ToString(),
                AccountNumber = t.AccountNumber,
                Amount = t.Amount,
                Currency = t.Currency,
                Type = t.Type,
                Description = t.Description,
                Status = t.Status,
                TransactionDate = t.TransactionDate,
                Channel = t.Channel
            })
            .ToListAsync();

        return new PagedResult<TransactionDTO>
        {
            Items = transactions,
            TotalRecords = totalRecords,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }

    public async Task<TransactionDTO> GetTransactionByIdAsync(Guid transactionId)
    {
        var transaction = await _context.Transactions
            .FirstOrDefaultAsync(t => t.Id == transactionId);

        if (transaction == null)
            return null;

        return new TransactionDTO
        {
            TransactionId = transaction.Id.ToString(),
            AccountNumber = transaction.AccountNumber,
            Amount = transaction.Amount,
            Currency = transaction.Currency,
            Type = transaction.Type,
            Description = transaction.Description,
            Status = transaction.Status,
            TransactionDate = transaction.TransactionDate,
            Channel = transaction.Channel
        };
    }

    public async Task<Transaction> CreateTransactionAsync(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();
        return transaction;
    }
}
