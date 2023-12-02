using System.Text.Json.Serialization;

namespace BackendApp.Core.DTOs;

public class TransactionDto
{
    [JsonPropertyName("transaction_id")]
    public string Transaction_id { get; set; }  = string.Empty;

    [JsonPropertyName("account_id"), JsonRequired]
    public Guid Account_id { get; set; }

    [JsonPropertyName("amount"), JsonRequired]
    public int Amount { get; set; }

    [JsonPropertyName("created_at"), JsonRequired]
    public DateTime Created_at { get; set; }
}
