using System.Text.Json.Serialization;

namespace BackendApp.Core.DTOs;

public class AccountDto
{
    [JsonPropertyName("balance"), JsonRequired]
    public int Balance { get; set; }
}
