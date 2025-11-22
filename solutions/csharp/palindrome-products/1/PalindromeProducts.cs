public static class PalindromeProducts
{
    public static (int, IEnumerable<(int, int)>) Largest(int minFactor, int maxFactor)
    {
        if (minFactor >= maxFactor)
            throw new ArgumentException("minFactor must be less than or equal to maxFactor");
        (int, IEnumerable<(int, int)>) result = (default, default)!;
        var palindromes = FindPalindromesInRange(minFactor, maxFactor);
        if (palindromes.Count() == 0)
            throw new ArgumentException("No palindromes found in the range");
        result.Item1 = palindromes.Last();
        result.Item2 = GetFactors(result.Item1, (minFactor, maxFactor));
        return result;
    }

    public static (int, IEnumerable<(int, int)>) Smallest(int minFactor, int maxFactor)
    {
        if (minFactor >= maxFactor)
            throw new ArgumentException("minFactor must be less than or equal to maxFactor");
        (int, IEnumerable<(int, int)>) result = (default, default)!;
        var palindromes = FindPalindromesInRange(minFactor, maxFactor);
        if (palindromes.Count() == 0)
            throw new ArgumentException("No palindromes found in the range");
        result.Item1 = palindromes.First();
        result.Item2 = GetFactors(result.Item1, (minFactor, maxFactor));
        return result;
    }

    public static IEnumerable<int> FindPalindromesInRange(int minFactor, int maxFactor)
    {
        var result = new HashSet<int>();
        if (minFactor > maxFactor)
            return result;
        for (int i = minFactor; i <= maxFactor; i++)
        {
            for (int j = i; j <= maxFactor; j++)
            {
                var product = i * j;
                if (IsPalindrome(product))
                {
                    result.Add(product);
                }
            }
        }
        return result.OrderBy(x => x);
    }

    private static IEnumerable<(int, int)> GetFactors(int number, (int, int) range)
    {
        List<(int, int)> factors = [];
        if (number <= 0)
            return factors;

        for (int i = range.Item1 ; i <= number; i++)
        {
            if (number % i == 0)
            {
                if (
                    (i >= range.Item1 && i <= range.Item2)
                    && (number / i >= range.Item1 && number / i <= range.Item2)
                    && !factors.Contains((number / i, i))
                )
                    factors.Add((i, number / i));
            }
        }
        return factors.ToArray();
    }

    private static bool IsPalindrome(int number)
    {
        var flipped = string.Concat(number.ToString().Reverse());
        return number.ToString() == flipped;
    }
}
