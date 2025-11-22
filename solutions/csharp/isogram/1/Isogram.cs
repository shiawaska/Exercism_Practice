using System;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        // array of booleans corresponding to the alphabet
        var letters = new bool[26];
        // loop through word array 
        foreach (var c in word.ToLower())
        {
            // ignore non-letters, letter - a == boolean index (0-25)
            // if bool at that index is true then return false
            if (char.IsLetter(c) && letters[c - 'a'])
            {
                return false;
            }
            // check if isletter and set boolean at the index to true
            if (char.IsLetter(c))
            {
                letters[c - 'a'] = true;
            }
        }
        return true;
    }
}
