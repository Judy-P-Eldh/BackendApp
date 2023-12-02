using System.Text.Json.Serialization;

namespace BackendApp.Core.DTOs;

public class AccountDto
{
    [JsonPropertyName("account_id"), JsonRequired]
    public Guid Account_id { get; set; }

    [JsonPropertyName("balance"), JsonRequired]
    public int Balance { get; set; }

    public ICollection<TransactionDto>? Transactions { get; set; }

    public int Amount { get; set; }
}
