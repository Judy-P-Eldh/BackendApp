﻿using AutoMapper;
using BackendApp.Core.DTOs;
using BackendApp.Core.Enteties;
using BackendApp.Data;
using BackendApp.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendApp.Controllers;

[Route("/transactions")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly BackenAppContext _db;
    private readonly IMapper _mapper;
    private readonly ITransactionRepository _transactionRepo;

    public TransactionsController(BackenAppContext context, IMapper mapper, ITransactionRepository transactionRepo)
    {
        _db = context;
        _mapper = mapper;
        _transactionRepo = transactionRepo;
    }

    // GET: api/Transactions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTransactionsAsync()
    {
        var transactions = await _transactionRepo.GetTransactionsAsync();
        return Ok(_mapper.Map<IEnumerable<TransactionDto>>(transactions));
    }                                                                                   

    // GET: api/Transactions/5
    [HttpGet("{id}")]
    public async Task<ActionResult> GetTransaction(string id)
    {
        var transaction = await _transactionRepo.GetTransactionAsync(id);

        if (transaction == null) return NotFound();
        
        return Ok(_mapper.Map<TransactionDto>(transaction));
    }

    // POST: api/Transactions
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Transaction>> CreateTransaction([FromBody] TransactionRequestDto transactionRequest)
    {
        if (transactionRequest == null)
        {
            return Problem("Request is null");
        }

        var transaction = new Transaction
        {
            Account_id = transactionRequest.Account_id.ToString(),
            Amount = transactionRequest.Amount,
            Created_at = DateTime.Now,
            Transaction_id = Guid.NewGuid().ToString(),
        };

        _db.Transactions.Add(transaction);
        await _db.SaveChangesAsync();

        return CreatedAtAction("GetTransaction", new { id = transaction.Transaction_id }, transaction);
    }

    private bool TransactionExists(string id)
    {
        return (_db.Transactions?.Any(e => e.Transaction_id == id)).GetValueOrDefault();
    }
}
