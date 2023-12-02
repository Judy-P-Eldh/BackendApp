using System.Text.Json.Serialization;

namespace BackendApp.Core.Enteties;

public class TransactionRequest
{
    public Guid Request_id { get; set; }

    [JsonPropertyName("account_id"), JsonRequired]
    public string Account_id { get; set; }   = string.Empty;

    [JsonPropertyName("amount"), JsonRequired]
    public int Amount { get; set; }

    [JsonPropertyName("transaction_id"), JsonRequired]
    public string Transaction_id { get; set; } = string.Empty;
}
