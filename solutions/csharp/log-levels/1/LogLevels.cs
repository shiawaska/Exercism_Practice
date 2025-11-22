using System;

static class LogLine
{
    public static string Message(string logLine)
    {
        // throw new NotImplementedException("Please implement the (static) LogLine.Message() method");
        int index = logLine.IndexOf(": ");       
        string message = logLine.Substring(index + 2);
        message = message.Replace("\t", "").Replace("\r", "").Replace("\n", "").Trim();        
        return message;
    }

    public static string LogLevel(string logLine)
    {
        // throw new NotImplementedException("Please implement the (static) LogLine.LogLevel() method");
        int index = logLine.IndexOf(": ");       
        string message = logLine.Remove(index);
        message = message.Trim('[',']');
        message = message.ToLower();
        return message;
    }

    public static string Reformat(string logLine)
    {
        // throw new NotImplementedException("Please implement the (static) LogLine.Reformat() method");
        int index = logLine.IndexOf(": ");       
        string level = logLine.Remove(index);
        level = level.Replace("[","(").Replace("]",")");
        level = level.ToLower();
               
        string message = logLine.Substring(index + 2);
        message = message.Replace("\t", "").Replace("\r", "").Replace("\n", "").Trim();

        string answer = message + " " + level;
        return answer;
        
    }
}
