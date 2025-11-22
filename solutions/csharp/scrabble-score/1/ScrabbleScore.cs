using System;
using System.Collections.Generic;

public static class ScrabbleScore
{
    // score values for each letter
    private static readonly Dictionary<char, int> letterValues = new Dictionary<char, int>
    {
        {'A', 1}, {'B', 3}, {'C', 3}, {'D', 2}, {'E', 1},
        {'F', 4}, {'G', 2}, {'H', 4}, {'I', 1}, {'J', 8},
        {'K', 5}, {'L', 1}, {'M', 3}, {'N', 1}, {'O', 1},
        {'P', 3}, {'Q', 10}, {'R', 1}, {'S', 1}, {'T', 1},
        {'U', 1}, {'V', 4}, {'W', 4}, {'X', 8}, {'Y', 4},
        {'Z', 10}
    };

    public static int Score(string input)
    {
        int TotalScore = 0;
       // search through string (making sure each character is uppercase)
        foreach (char c in input.ToUpper())
        {
            // if dictionary cotains a key matching the char held in c
            if (letterValues.ContainsKey(c))
            {
                // add value from the KVP to the score
                TotalScore += letterValues[c];
            }
        }
        return TotalScore;
    }
}