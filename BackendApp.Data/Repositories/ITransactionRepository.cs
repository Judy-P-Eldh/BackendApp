using BackendApp.Core.Enteties;
using System.Threading.Tasks;

namespace BackendApp.Data.Repositories;

public interface ITransactionRepository
{
    Task<Transaction> CreateAsync(TransactionRequest transactionRequest);
    Task<List<Transaction>> GetTransactionsAsync();
    Task<Transaction> GetTransactionAsync(string id);
    Task<bool> TransactionExistsAsync(string transaction_id);
    Task<bool> RequestExistsAsync(string request_id);
}