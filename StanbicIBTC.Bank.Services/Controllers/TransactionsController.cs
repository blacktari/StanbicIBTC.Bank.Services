using Microsoft.AspNetCore.Mvc;
using StanbicIBTC.Bank.Services.Interfaces;
using StanbicIBTC.Bank.Services.Models;
using System;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionsController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTransactions([FromQuery] TransactionRequest request)
    {
        var pagedTransactions = await _transactionService.GetTransactionsAsync(request);
        return Ok(pagedTransactions);
    }

    [HttpGet("{transactionId}")]
    public async Task<IActionResult> GetTransactionById(Guid transactionId)
    {
        var transaction = await _transactionService.GetTransactionByIdAsync(transactionId);
        if (transaction == null)
            return NotFound(new { Message = "Transaction not found." });

        return Ok(transaction);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction([FromBody] Transaction transaction)
    {
        if (transaction == null)
        {
            return BadRequest("Invalid transaction data.");
        }

        transaction.Id = Guid.NewGuid(); // Generate TransactionId if not set

        var createdTransaction = await _transactionService.CreateTransactionAsync(transaction);
        return CreatedAtAction(nameof(GetTransactionById), new { transactionId = createdTransaction.Id }, createdTransaction);
    }
}
