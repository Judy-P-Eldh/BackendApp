namespace BackendApp.Core.DTOs;

public class ListOfTransactionsDto
{
    public ICollection<TransactionDto>? Transactions { get; set; } = new List<TransactionDto>();
    public TransactionDto? Transaction { get; set; }
    public Guid? Transaction_id { get; set; }
    public int TransactionAmount { get; set; }
    public AccountDto? Account { get; set; }
    public int Balance { get; set; }
    public Guid? Account_id { get; set; }
}
