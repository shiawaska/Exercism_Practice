using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if (balance < (decimal) 0.0)
            return 3.213f;
        if (balance >= (decimal)0.0 && balance < 1000)
            return 0.5f;
        if (balance >= 1000 && balance < 5000)
            return 1.621f;
        if (balance >= 5000)
            return 2.475f;
        return 0.0f;
    }

    public static decimal Interest(decimal balance)
    {
        // throw new NotImplementedException("Please implement the (static) SavingsAccount.Interest() method");
       float interestRate = InterestRate(balance);
        interestRate /= 100;                // convert interest rate to a %
       decimal interest =  (decimal) interestRate * balance;
           return (decimal) interest;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        float interestRate = InterestRate(balance) / 100;
        balance = balance * (decimal)interestRate + balance;
        return balance;
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {        
        int years = 0;             
        float interestRate = InterestRate(balance) / 100;
        balance = balance * (decimal) interestRate + balance;
        years ++; 
        if (balance <= targetBalance)
            years += YearsBeforeDesiredBalance(balance,targetBalance);  
        return years;
    }
}
