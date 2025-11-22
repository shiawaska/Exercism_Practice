using System;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        //  set entire string to lowercase
        var InputString = input.ToLower();
        
        // initalize an output variable
        var OutputString = "";
        // loop  through string
        foreach (char c in InputString)
        {
            // check if char is a letter before touching it
            if (Char.IsLetter(c))
            {
                // check if the letter is already in the output string
                if (!OutputString.Contains(c))
                {
                    OutputString += c;
                }
            }
        }
        // if the output string contains all 26 lowercase letters then its true
        return OutputString.Length == 26;
    }
}
