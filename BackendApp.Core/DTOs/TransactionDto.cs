using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BackendApp.Core.DTOs;

public class TransactionDto
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
