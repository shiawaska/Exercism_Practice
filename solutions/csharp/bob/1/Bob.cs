using System;

public static class Bob
{
    public static string Response(string statement)
    {
        bool isQuestion = statement.Trim().EndsWith("?");
        bool isSilence = string.IsNullOrWhiteSpace(statement);
        bool isYelling = statement.ToUpper() == statement && statement.ToLower() != statement;

        if (isYelling && !isQuestion)
        {
            return "Whoa, chill out!";
        }
        if (!isYelling && isQuestion) 
        {
            return "Sure.";
        }
        if (isYelling && isQuestion)
        {
            return "Calm down, I know what I'm doing!";
        }
        if (isSilence)
        {
            return "Fine. Be that way!";
        }
        return "Whatever.";
    }
}