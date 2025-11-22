public static class Knapsack
{
    public static int MaximumValue(int maximumWeight, (int weight, int value)[] items)
    {
        int maskSize = items.Length;

        return Enumerable.Range(0, 1 << maskSize)
            .Select(mask => Bag(mask, items))
            .ToArray().Where(bag => bag.Item1 <= maximumWeight)
            .OrderByDescending(bag => bag.Item2)
            .ThenBy(bag => bag.Item1)
            .FirstOrDefault()
            .Item2;

    }

    private static (int, int) Bag(int mask, (int weight, int value)[] items) =>
        Enumerable
            .Range(0, items.Length)
            .Where(bit => (mask & (1 << bit)) != 0)
            .Aggregate(
                (0, 0),
                (acc, bit) => (acc.Item1 + items[bit].weight, acc.Item2 + items[bit].value)
            );
}