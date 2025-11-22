public static class Knapsack
{
    public static int MaximumValue(int maximumWeight, (int weight, int value)[] items)
    {
        int maskSize = items.Length;
        
        (int, int)[] bags = new (int, int)[1 << maskSize];

        for (int mask = 0; mask < (1 << maskSize); mask++)
        {
            bags[mask] = Bag(mask, items);
        }

        return bags.Where(bag => bag.Item1 <= maximumWeight)
            .OrderByDescending(bag => bag.Item2)
            .ThenBy(bag => bag.Item1)
            .FirstOrDefault()
            .Item2;
    }

    private static (int, int) Bag(int mask, (int weight, int value)[] items)
    {
        (int, int) bag = (0, 0);

        for (int bit = 0; bit < items.Length; bit++)
        {
            if ((mask & (1 << bit)) == 0)
                continue;
            bag.Item1 += items[bit].weight;
            bag.Item2 += items[bit].value;
        }
        return bag;
    }
}
