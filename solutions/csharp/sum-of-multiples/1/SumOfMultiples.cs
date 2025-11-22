public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        var uniqueMultiples = new HashSet<int>();
        foreach (var number in multiples)
        {
            foreach (var multiple in GetMultiplesBelowMax(number, max))
            {
                uniqueMultiples.Add(multiple);
            }
        }
        return uniqueMultiples.Sum();
    }

    public static int[] GetMultiplesBelowMax(int number, int max)
    {
        if (number <= 0 || max <= 0)
            return Array.Empty<int>();

        var result = new List<int>();
        for (int i = number; i < max; i += number)
        {
            result.Add(i);
        }
        return result.ToArray();
    }



}