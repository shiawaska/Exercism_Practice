public static class ResistorColor
{
    public static readonly Dictionary<string, int> ColorCodes = new Dictionary<string, int>
    {
        { "black", 0 },
        { "brown", 1 },
        { "red", 2 },
        { "orange", 3 },
        { "yellow", 4 },
        { "green", 5 },
        { "blue", 6 },
        { "violet", 7 },
        { "grey", 8 },
        { "white", 9 }
    };
    
    public static int ColorCode(string color)
    {
        ColorCodes.TryGetValue(color, out int value);
        return value;
    }

    public static string[] Colors()
    => ColorCodes.Keys.ToArray();
}