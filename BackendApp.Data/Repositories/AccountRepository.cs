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

    public async Task<Account> GetAccountAsync(string id)
    {
        return await _db.Accounts.FindAsync(id);
    }
}
