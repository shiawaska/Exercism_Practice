using System;

public static class LogAnalysis
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string str, string Delimiter)
    {
        if (string.IsNullOrEmpty(Delimiter) || string.IsNullOrWhiteSpace(Delimiter)) // check for invalid input
            return "Delimiter is invalid";
        int Delimiter_length = Delimiter.Length; 
        int strLen = str.Length;
        string answer = "Delimiter Not Found";
        for (int i = 0; i <= strLen - Delimiter_length; i++) // loop through string 
        {
            if (Delimiter == str.Substring(i, Delimiter_length)) // compare delimiter to string
            {
                answer = str.Substring(i + Delimiter_length); // save everything after found string
            }           
        }
        return answer;
    }

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string str, string Delimiter1, string Delimiter2)
    {
        // check for valid inputs
        if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
            return "input string is invalid";
        if (string.IsNullOrEmpty(Delimiter1) || string.IsNullOrWhiteSpace(Delimiter1))
            return "Delimiter 1 is invalid";
        if (string.IsNullOrEmpty(Delimiter2) || string.IsNullOrWhiteSpace(Delimiter2))
            return "Delimiter 2 is invalid";

        // function variables
        int Delimiter1_length = Delimiter1.Length;
        int Delimiter2_length = Delimiter2.Length;
        int strLen = str.Length;
        int Delimiter1_location = -1;
        int Delimiter2_location = -1;

        for (int i = 0; i < strLen; i++)                                // loop through string
        {
            if (Delimiter1 == str.Substring(i, Delimiter1_length))    // compare first delimiter
            {
                Delimiter1_location = i + Delimiter1_length;            // save delimiter location
            }

            else if (Delimiter2 == str.Substring(i, Delimiter2_length)) // compare second delimiter
            {
                Delimiter2_location = i - Delimiter1_location;        // save length of string to be returned
            }
            else if (Delimiter1_location != -1 && Delimiter2_location != -1)    // if both delimiters found
                return str.Substring(Delimiter1_location, Delimiter2_location); // return string

        }
        return "one or more Delimiters could not be found";
    }

    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string str)
    {
        return str.SubstringAfter(": ");        // return from function using magic value
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");    // return from function using magic values
    }
}