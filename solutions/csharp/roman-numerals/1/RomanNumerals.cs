using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Text;

public static class RomanNumeralExtension
{
    public static string ToRoman(this int value)
    {
        if (value > 3999 || value < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 1 and 3999.");
        }

        var numeralsOrder = new List<char> { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };
        var numeralsList = new List<(int count, char numeral)>();
        int currentValue = value;
        foreach (var numeral in numeralsOrder)
        {
            var (remaining, count) = GetNumericalCount(currentValue, numeral);
            numeralsList.Add((count, numeral));
            currentValue = remaining;
        }
        return OrganizeNumerals(numeralsList);
    }

    private static Dictionary<char, int> numerals = new Dictionary<char, int>
    {
       // 59 is LIX
        { 'M', 1000 },
        { 'D', 500 },
        { 'C', 100 },
        { 'L', 50 }, // 1
        { 'X', 10 }, 
        { 'V', 5 },  // 1
        { 'I', 1 },  // 4
    };

    private static (int value, int numeralCount) GetNumericalCount(int value, char numeral)
    {
        var number = value;
        var numeralCount = 0;

        while (number >= numerals[numeral])
        {
            number = number - numerals[numeral];
            numeralCount = numeralCount + 1;
        }
        return (number, numeralCount);
    }

    private static string OrganizeNumerals(List<(int count, char numeral)> numeralsList)
    {
        var stringBuilder = new StringBuilder();
        for (int i = 0; i != numeralsList.Count; i++)
        {
            if (numeralsList[i].count == 0)
            {
                stringBuilder.Append("");
                continue;
            }
            if (numeralsList[i].count < 4)
            {
                var numeral = numeralsList[i];
                stringBuilder.Append(numeral.numeral, numeral.count);
                continue;
            }
            if (numeralsList[i].count == 4 && numeralsList[i - 1].count == 0)
            {
                stringBuilder.Append($"{numeralsList[i].numeral}{numeralsList[i - 1].numeral}");
                continue;
            }
            else if (numeralsList[i].count == 4 && numeralsList[i - 1].count > 0)
            {
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                stringBuilder.Append($"{numeralsList[i].numeral}{numeralsList[i - 2].numeral}");
                continue;
            }
        }
        return stringBuilder.ToString().Trim();
    }
}
