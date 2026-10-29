// interest_rate returns the interest rate for the provided balance.
double interest_rate(double balance)
{
    double interest = 0;

    if (balance < 0)
        interest = 3.213;
    if (balance >= 0)
        interest = 0.5;
    if (balance >= 1000)
        interest = 1.621;
    if (balance >= 5000)
        interest = 2.475;

    return interest;
}

// yearly_interest calculates the yearly interest for the provided balance.
double yearly_interest(double balance)
{
    auto interestRate = interest_rate(balance) / 100;
    auto final_balance = balance;
    final_balance += final_balance * interestRate;
    return final_balance - balance;
}

// annual_balance_update calculates the annual balance update, taking into
// account the interest rate.
double annual_balance_update(double balance)
{
    return balance + yearly_interest(balance);
}

// years_until_desired_balance calculates the minimum number of years required
// to reach the desired balance.
int years_until_desired_balance(double balance, double target_balance)
{
    // TODO: Implement the years_until_desired_balance function
    int years = 0;
    auto current_balance = balance;
    while (current_balance < target_balance)
    {
        current_balance = annual_balance_update(current_balance);
        years++;
    }
    return years;
}
