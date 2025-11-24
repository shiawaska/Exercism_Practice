using System.Collections.Generic;

public static class BottleSong
{
    
    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        for (int bottle = startBottles; bottle > startBottles - takeDown; bottle --)
        {
            string capitalCount = char.ToUpper(BottleNumber(bottle)[0]) + BottleNumber(bottle).Substring(1);
            yield return $"{capitalCount} green {IsPLural(bottle)} hanging on the wall,";
            yield return $"{capitalCount} green {IsPLural(bottle)} hanging on the wall,";
            yield return "And if one green bottle should accidentally fall,";
            yield return $"There'll be {BottleNumber(bottle - 1)} green {IsPLural(bottle - 1)} hanging on the wall.";

            if (bottle > startBottles - takeDown + 1)
            {
                yield return "";
            }
        }
        
    }
    
    private static string BottleNumber(int count) =>
     count switch
    {
        0 => "no",
        1 => "one",
        2 => "two",
        3 => "three",
        4 => "four",
        5 => "five",
        6 => "six",
        7 => "seven",
        8 => "eight",
        9 => "nine",
        10 => "ten",
        _ => ""
    };
    
    private static string IsPLural(int count) => count == 1 ? "bottle" : "bottles";
}
