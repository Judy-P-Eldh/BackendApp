using BackendApp.Core.Enteties;
using Microsoft.EntityFrameworkCore;

namespace BackendApp.Data.Repositories
{
    public class TransactionRepository   : ITransactionRepository
    {
        private readonly BackenAppContext _db;

        public TransactionRepository(BackenAppContext db)
        {
            _db = db;
        }

        public async Task<Transaction> CreateAsync(TransactionRequest transactionRequest)
        {
            transactionRequest = new TransactionRequest
            {
                Transaction_id = Guid.NewGuid().ToString(),
                Account_id = transactionRequest.Account_id,
                Amount = transactionRequest.Amount,
                Request_id = Guid.NewGuid(),
            };

            if (await RequestExistsAsync(transactionRequest.Request_id.ToString()))
            {
                throw new Exception("TreansactionRequest already exists");
            }

            if (await TransactionExistsAsync(transactionRequest.Transaction_id))
            {
                throw new Exception("Treansaction already exists");
            }

            var transaction = new Transaction
            {
                Account_id = transactionRequest.Account_id.ToString(),
                Amount = transactionRequest.Amount,
                Created_at = DateTime.Now,
                Transaction_id = transactionRequest.Transaction_id,
            };

            return transaction;
        }

        public async Task<List<Transaction>> GetTransactionsAsync()
        {
            return await _db.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetTransactionAsync(string id)
        {
            return await _db.Transactions.FindAsync(id);
        }

        public async Task<bool> TransactionExistsAsync(string transaction_id)
        {
            return await _db.Transactions.AnyAsync(t => t.Transaction_id == transaction_id);
        }

        public async Task<bool> RequestExistsAsync(string request_id)
        {
            return await _db.TransactionRequests.AnyAsync(r => r.Request_id.ToString() == request_id);
        }
    }
}
