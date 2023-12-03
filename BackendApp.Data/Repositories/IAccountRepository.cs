using BackendApp.Core.Enteties;

namespace BackendApp.Data.Repositories
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAccountsAsync();
        Task<Account> GetAccountAsync(string account_id);
        Task<int> UpdateBalance(int amount, string account_id);
        Task<bool> AccountExistsAsync(string account_id);
    }
}