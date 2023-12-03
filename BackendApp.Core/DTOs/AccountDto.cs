using System.Text.Json.Serialization;

namespace BackendApp.Core.DTOs;

public class AccountDto
{
    public string Account_id { get; set; }
    [JsonPropertyName("balance"), JsonRequired]
    public int Balance { get; set; }
}
