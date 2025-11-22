using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var result = new StringBuilder();
        bool isPreviousCharDash = false;
        
        foreach (char c in identifier)
            {

            // is a char after a dash
            if (isPreviousCharDash)
            {
                char upperC = char.ToUpper(c);
                result.Append(upperC);
                isPreviousCharDash = false;
                continue;
            }

            // is a whitespace
            if (char.IsWhiteSpace(c))
            {
                // underscore
               result.Append('_');
                continue;
            }

            // is a control character
            if (char.IsControl(c))
            {
                
                result.Append("CTRL");
                continue;
            }

            // char is a dash
            if (c == '-')
            {             
                isPreviousCharDash = true;
                continue;
            }

            // char is a letter 
            if (char.IsLetter(c) && (c < 'α' || c > 'ω'))
            {
                result.Append(c);
                continue;
            }

           
    }
        return result.ToString();
}
}
