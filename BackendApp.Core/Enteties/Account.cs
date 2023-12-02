using System.Text.Json.Serialization;
using System.Transactions;

namespace BackendApp.Core.Enteties;

public class Account
{
    [JsonPropertyName("account_id"), JsonRequired]
    public Guid Account_id { get; set; }

    [JsonPropertyName("balance"), JsonRequired]
    public int Balance { get; set; }

    public ICollection<Transaction>? Transactions { get; set; }

    public int Amount { get; set; }

    public Account()
    {
        Balance = 0;
        Transactions = new List<Transaction>();
    }

    public void UpdateBalance(int amount)
    {
        Balance += amount; // Update the balance
    }
}
