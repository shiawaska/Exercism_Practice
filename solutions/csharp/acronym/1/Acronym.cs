using System;
using System.Text;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var _phrase = phrase;
        bool _isFirstLetter = true;
        bool _isSpaceOrHyphen = false;
        var _output = new StringBuilder();

        // capitalize the first letter of the phrase
        // and any letter that follows a space or a hyphen
        // add the capital letter to the output string
        foreach (var c in _phrase)
        {
            if (char.IsLetter(c))
            {
                if (_isFirstLetter || _isSpaceOrHyphen)
                {
                    var _letter = char.ToUpper(c);
                    _isFirstLetter = false;
                    _isSpaceOrHyphen = false;
                    _output.Append(_letter);
                }
            }
            if (c == ' ' || c == '-')
            {
                _isSpaceOrHyphen = true;
            }
            
        }
        return _output.ToString();
    }
}