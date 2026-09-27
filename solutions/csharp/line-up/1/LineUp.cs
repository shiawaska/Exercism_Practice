public static class LineUp
{
    public static string Format(string name, int number)
    {
        var last2Numbers = number % 100;

        string tense;
        if (last2Numbers is 11 or 12 or 13)
        {
            tense = "th";
        }
        else if (number % 10 == 1)
        {
            tense = "st";
        }
        else if (number % 10 == 2)
        {
            tense = "nd";
        }
        else if (number % 10 == 3)
        {
            tense = "rd";
        }
        else
        {
            tense = "th";
        }

        return $"{name}, you are the {number}{tense} customer we serve today. Thank you!";
    }
}
