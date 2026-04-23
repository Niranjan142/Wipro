using System;
public class InvalidAmountException : Exception
{
    public InvalidAmountException(string message) : base(message)
    {
    }
}

public class InvalidFundsException : Exception
{
    public InvalidFundsException(string message) : base(message)
    {
    }
}


class BankAccount
{
    public string AccountHolderName { get; set; }
    public double Balance { get; set; }

    public BankAccount(string accountHolderName, double balance)
    {
        AccountHolderName = accountHolderName;
        Balance = balance;
    }
    public void Deposit(double amount)
    {
        if(amount<0)
            throw new InvalidAmountException("Enter amount greater than zero.");
        Balance += amount;
        Console.WriteLine($"Deposited {amount}. New balance is {Balance}.");
    }

    public void Withdraw(double amount)
    {
        if(amount<0)
            throw new InvalidAmountException("Enter amount greater than zero.");
        if (amount > Balance)
        {
            throw new InvalidAmountException("Insufficient funds.");
        }
        Balance -= amount;
        Console.WriteLine($"Withdrew {amount}. New balance is {Balance}.");
    }

    public void DisplayBalance()
    {
        Console.WriteLine($"Account Holder: {AccountHolderName}, Balance: {Balance}");
    }

}

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount("John Doe", 1000.0);
        try
        {
            Console.WriteLine("1. Deposit\n2.Withdraw\n3.Display Balance");
            Console.WriteLine("Enter your choice:");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter amount to deposit:");
                    double dep = int.Parse(Console.ReadLine());
                    account.Deposit(dep);
                    break;
                case 2:
                    Console.WriteLine("Enter amount to withdraw:");
                    double with = int.Parse(Console.ReadLine());
                    account.Withdraw(with);
                    break;
                case 3:
                    account.DisplayBalance();
                    break;
                default:
                    throw new ArgumentException("Invalid choice.");
            }
        }
        catch (InvalidAmountException e)
        {
            Console.WriteLine("Error" + e.Message);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        catch (InvalidFundsException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (FormatException e)
        {
            Console.WriteLine("Input format error: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("An unexpected error occurred: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Transaction completed.");

        }
    }
}
