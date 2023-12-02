using BackendApp.Core.Enteties;

namespace BackendApp.Data.Repositories;

public interface ITransactionRepository
{
    Task<List<Transaction>> GetTransactionsAsync();
    Task<Transaction> GetTransactionAsync(string id);
}