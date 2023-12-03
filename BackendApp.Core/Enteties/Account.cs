using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackendApp.Core.Enteties;

public class Account
{
    [JsonPropertyName("account_id")]
    [Required]
    public string Account_id { get; set; }   = string.Empty;

    [JsonPropertyName("balance")]
    public int Balance { get; set; }
}
