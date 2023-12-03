using AutoMapper;
using BackendApp.Core.DTOs;
using BackendApp.Core.Enteties;
using BackendApp.Data;
using BackendApp.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp.Controllers;

[Route("/accounts")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly BackenAppContext _db;
    private readonly IMapper _mapper;
    private readonly IAccountRepository _accounttionRepo;

    public AccountsController(BackenAppContext db, IMapper mapper, IAccountRepository accounttionRepo)
    {
        _db = db;
        _mapper = mapper;
        _accounttionRepo = accounttionRepo;
    }

    // GET: api/Accounts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccountsAsync()
    {
        var accounts = await _accounttionRepo.GetAccountsAsync();
        return Ok(_mapper.Map<IEnumerable<AccountDto>>(accounts));
    }

    // GET: api/Accounts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AccountDto>> GetAccount(string id)
    {
        var account = await _accounttionRepo.GetAccountAsync(id);

        if (account == null) return NotFound();

        return Ok(_mapper.Map<AccountDto>(account));
    }

    //Method only for adding dummy data to db
    // POST: api/Accounts
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Account>> PostAccount(AccountDto account)
    {
        if (_db.Accounts == null)
        {
            return Problem("Entity set 'BackenAppContext.Accounts'  is null.");
        }

        var createdAccount = new Account()
        {
            Account_id = Guid.NewGuid().ToString(),
            Balance = account.Balance,
        };

        _db.Accounts.Add(createdAccount);
        await _db.SaveChangesAsync();

        return CreatedAtAction("GetAccount", new { id = createdAccount.Account_id }, account);
    }
}
