using BackendApp.Core.Enteties;

namespace BackendApp.Data.Repositories
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAccountsAsync();
        Task<Account> GetAccountAsync(string id);
    }
}