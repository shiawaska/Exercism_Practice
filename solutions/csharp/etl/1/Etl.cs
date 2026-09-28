public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old) =>
        old.SelectMany(kvp =>
                kvp.Value.Select(letter => new { Letter = letter.ToLowerInvariant(), Score = kvp.Key })
            )
            .ToDictionary(item => item.Letter, item => item.Score);
}
