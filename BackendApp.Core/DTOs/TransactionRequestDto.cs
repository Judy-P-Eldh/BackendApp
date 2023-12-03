using System.Text.Json.Serialization;

namespace BackendApp.Core.DTOs;

public class TransactionRequestDto
{
    [JsonPropertyName("account_id"), JsonRequired]
    public string Account_id { get; set; }

    [JsonPropertyName("amount"), JsonRequired]
    public int Amount { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? Created_at { get; set; }
}
