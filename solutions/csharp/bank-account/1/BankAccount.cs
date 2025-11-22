public class BankAccount
{
     Account account = new Account();
    public void Open()
    {
        if (account.isOpen)
        {
            throw new InvalidOperationException();
        }
        account.isOpen = true;
        account.Balance = 0;
    }

    public void Close()
    {
        if (!account.isOpen)
        {
            throw new InvalidOperationException();
        }
        
        if (account.isOpen)
        {
            account.isOpen = false;
            account.Balance = 0;
        }
    }

    public decimal Balance
    {
        get
        {
            if (!account.isOpen)
            {
                throw new InvalidOperationException();
            }
            return account.Balance;
        }
    }

    public void Deposit(decimal change)
    {
        if (!account.isOpen)
        {
            throw new InvalidOperationException();
        }
        
        if (change < 0)
        {
            throw new InvalidOperationException();
        }
        
        account.Balance += change;
    }

    public void Withdraw(decimal change)
    {
        if (!account.isOpen)
        {
            throw new InvalidOperationException();
        }

        if (change < 0)
        {
            throw new InvalidOperationException();
        }
        
        if (account.Balance < change)
        {
            throw new InvalidOperationException();
        }
        account.Balance -= change;
    }
}

public class Account
{
    public bool isOpen { get; set; }
    public decimal Balance { get; set; }
}
