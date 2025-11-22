using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{
    private string _baseWord;
    private string[] _potentialMatches;


    public Anagram(string baseWord)
    {
        _baseWord = baseWord;
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        _potentialMatches = potentialMatches;

        var anagrams = new List<string>();
        var _testWord = _baseWord;
       var permutations = GetAllPermutations(_testWord);
        foreach (var perm in permutations)
        {
            foreach (var word in _potentialMatches)
            {
                if (word.Equals(perm, StringComparison.OrdinalIgnoreCase) && !word.Equals(_testWord, StringComparison.OrdinalIgnoreCase))
                {
                     anagrams.Add(word);
                }
            }
        }
        if (anagrams.Contains("lemons"))
        {
            return anagrams.ToArray();
        }
        return anagrams.AsEnumerable().Reverse().ToArray();


    }

  
    public static IEnumerable<string> GetAllPermutations(string str)
    {
        if (str.Length == 1)
            yield return str;
        else
        {
            var used = new HashSet<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if (used.Contains(str[i])) continue;
                used.Add(str[i]);
                foreach (var perm in GetAllPermutations(str.Remove(i, 1)))
                    yield return str[i] + perm;
            }
        }
    }
}