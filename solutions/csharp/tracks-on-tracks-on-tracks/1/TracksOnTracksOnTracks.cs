public static class Languages
{
    public static List<string> NewList() => [];

    public static List<string> GetExistingLanguages()
        => [
        "C#", "Clojure", "Elm"
    ];

    public static List<string> AddLanguage(List<string> languages, string language)
    {
         languages.Add(language);
         return languages;
    }

    public static int CountLanguages(List<string> languages)
        => languages.Count;

    public static bool HasLanguage(List<string> languages, string language)
       => languages.Contains(language);

    public static List<string> ReverseList(List<string> languages)
    {
      languages.Reverse();
      return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        if (languages.Count == 0) return false;
        List<int> acceptableListSize = [1, 2, 3];
        if (languages[0] == "C#") return true;
            if (languages[1] == "C#" && acceptableListSize.Contains(languages.Count)) return true;
            return false;
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        for (int i = 0; i < languages.Count; i++)
        {
            var count = 0;
            foreach (var language in languages)
            {
                if (language == languages[i]) count++;
            }
            if (count > 1) return false;
        }
        return true;
    }
}
