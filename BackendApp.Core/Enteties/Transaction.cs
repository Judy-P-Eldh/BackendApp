using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackendApp.Core.Enteties;

public class Transaction
{
    [JsonPropertyName("transaction_id")]
    [Required]
    public string Transaction_id { get; set; } = string.Empty;

    [JsonPropertyName("account_id")]
    [Required]
    public string Account_id { get; set; } = string.Empty;

    [JsonPropertyName("amount"), JsonRequired]
    public int Amount { get; set; }

    [JsonPropertyName("created_at"), JsonRequired]
    public DateTime Created_at { get; set; }
}
