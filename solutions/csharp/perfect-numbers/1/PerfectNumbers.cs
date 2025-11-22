public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        var divisors = Divisors(number);
        Console.WriteLine("divisors", divisors);
        var total = 0;
        foreach (var item in divisors)
        {
           total += item;
        }
        total -= number;
        switch (total)
        {
            case var t when t > number:
                return Classification.Abundant;
            case var t when t == number:
                return Classification.Perfect;
            case var t when t < number:
                return Classification.Deficient;
            default:
                return Classification.Deficient;
        }
    }

    public static List<int> Divisors(int n)
    {
        List<int> divisors = new List<int>();

        for (int i = 1; i <= n; i++)
        {
            // i is a divisor of n
            if (n % i == 0)
            {
                divisors.Add(i);
            }
        }

        return divisors;
    }
}

