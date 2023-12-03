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

        //public async Task CreateAsync(TransactionRequest transactionRequest)
        //{
        //    if (FindMadeTransactions(transactionRequest))
        //    {
        //        throw new Exception("Transaction already exists");
        //    }
        //    var transaction = new Transaction
        //    {
        //        Account_id = transactionRequest.Account_id,
        //        Amount = transactionRequest.Amount,
        //        Created_at = DateTime.UtcNow,
        //        Transaction_id = transactionRequest.Transaction_id,
        //    };

        //    await _db.Transactions.AddAsync(transaction);
        //    await SaveChangesAsync();
        //}

        public async Task<List<Transaction>> GetTransactionsAsync()
        {
            return await _db.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetTransactionAsync(string id)
        {
            return await _db.Transactions.FindAsync(id);
        }
        public bool FindMadeTransactions(TransactionRequest transactionRequest)
        {
            var madeTransaction = _db.Transactions
                .OrderBy(t => t.Transaction_id)
                .Where(t => t.Transaction_id == transactionRequest.Transaction_id);
            if (madeTransaction == null) return false;
            return true;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync() >= 1;
        }
    }
}
