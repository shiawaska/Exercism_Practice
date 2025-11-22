using System;
using System.Reflection.Metadata.Ecma335;
using System.Text;

public static class RotationalCipher
{

    public static string Rotate(string text, int shiftKey)
    {
        // length of the alphabet
        int LanguageLength = 26;
        // create a string builder to store the text
        var _text = new StringBuilder();
        

        if (text == null || shiftKey <= 0 || shiftKey > 26)
        {
            return text;
        }
        foreach (char c in text)
        {
            // is a letter
            if (char.IsLetter(c) && char.IsUpper(c))
            {
                // apply shiftkey to the character
                var character = (char)(c + shiftKey);
                // if still a character then append to the string builder
                if (char.IsUpper(character))
                {
                    _text.Append(character);
                    continue;
                }
                // else wrap around the alphabet
                else
                {
                    character = (char)(character - LanguageLength);
                    _text.Append(character);
                    continue;
                }
            }
            if (char.IsLetter(c) && char.IsLower(c))
                {
                    var character = (char)(c + shiftKey);
                    if (char.IsLower(character))
                    {
                        _text.Append(character);
                        continue;
                    }
                    else
                    {
                        character = (char)(character - LanguageLength);
                        _text.Append(character);
                        continue;
                    }
                }

            
            else
            {
                _text.Append(c);
                continue;
            }

        }
        return _text.ToString();

    }
}
