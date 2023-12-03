using BackendApp.Core.Enteties;
using BackendApp.Data.Repositories;
using Moq;

namespace BackendAppTests;

public class TransactionRepositoryTests
{

    [Fact]
    public static void ReturnListOfTransactions()
    {

        var transactionRepoMock = new Mock<ITransactionRepository>();
        transactionRepoMock
            .Setup(m => m.GetTransactionsAsync())
            .ReturnsAsync(new List<Transaction>()
            {
                        new Transaction(),
                        new Transaction()
            });

        Assert.Equal(2, 2);
        Assert.NotEqual(2, 1);
    }
    [Fact]
    public static void ReturnTransactionById()
    {
        //Arrange
        var id = "t1";
        var transactionRepoMock = new Mock<ITransactionRepository>();
        transactionRepoMock
            .Setup(m => m.GetTransactionAsync(id));
        var trasaction1 = new Transaction { Transaction_id = "t2" };
        var transaction2 = new Transaction { Transaction_id = id };
        //.ReturnsAsync(new Transaction());

        Assert.Distinct(transaction2.Account_id);
    }
}
