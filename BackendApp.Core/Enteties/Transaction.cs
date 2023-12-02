using System.Text.Json.Serialization;

namespace BackendApp.Core.Enteties;

public class Transaction
{
    [JsonPropertyName("transaction_id"), JsonRequired]
    public Guid Transaction_id { get; set; }

    [JsonPropertyName("account_id"), JsonRequired]
    public Guid Account_id { get; set; }

    [JsonPropertyName("amount"), JsonRequired]
    public int Amount { get; set; }

    [JsonPropertyName("created_at"), JsonRequired]
    public DateTime Created_at { get; set; }
}
