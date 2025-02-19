namespace Week03;
public class Program
{
    public static void Main()
    {
        var account = new BankAccount("Bob", 1000);
        Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
    }
}
