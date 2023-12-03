using AutoMapper;
using BackendApp.Core.Enteties;
using Microsoft.EntityFrameworkCore;

namespace BackendApp.Data.Repositories;

public class AccountRepository  : IAccountRepository
{
    private readonly BackenAppContext _db;

    public AccountRepository(BackenAppContext context)
    {
        _db = context;
    }

    public async Task<List<Account>> GetAccountsAsync()
    {
        return await _db.Accounts.ToListAsync();
    }

    public async Task<Account> GetAccountAsync(string account_id)
    {
        return await _db.Accounts.FindAsync(account_id);
    }

    public async Task<int> UpdateBalance(int amount, string account_id)
    {
        var account = _db.Accounts.Find(account_id);
        if (!await AccountExistsAsync(account_id)) return 00;
        
        return account.Balance += amount; 
    }

    public async Task<bool> AccountExistsAsync(string account_id)
    {
        return await _db.Accounts.AnyAsync(a => a.Account_id == account_id);
    }
}
