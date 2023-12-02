using BackendApp.Core.DTOs;
using BackendApp.Core.Enteties;
using BackendApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendApp.Controllers;

[Route("/accounts")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly BackenAppContext _db;

    public AccountsController(BackenAppContext db)
    {
        _db = db;
    }

    // GET: api/Accounts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
    {
        if (_db.Accounts == null)
        {
            return NotFound();
        }
        return await _db.Accounts.ToListAsync();
    }

    // GET: api/Accounts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Account>> GetAccount(Guid id)
    {
        if (_db.Accounts == null)
        {
            return NotFound();
        }
        var account = await _db.Accounts.FindAsync(id);

        if (account == null)
        {
            return NotFound();
        }

        return account;
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

    //// DELETE: api/Accounts/5
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteAccount(Guid id)
    //{
    //    if (_db.Accounts == null)
    //    {
    //        return NotFound();
    //    }
    //    var account = await _db.Accounts.FindAsync(id);
    //    if (account == null)
    //    {
    //        return NotFound();
    //    }

    //    _db.Accounts.Remove(account);
    //    await _db.SaveChangesAsync();

    //    return NoContent();
    //}

    private bool AccountExists(string id)
    {
        return (_db.Accounts?.Any(e => e.Account_id == id)).GetValueOrDefault();
    }
}
