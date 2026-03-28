using System.Text;

public class Robot
{
    private static readonly HashSet<string> NameRegistry = [];
    private char[] _alphabet =>  Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c).ToArray();
    public string Name
    {
        get => string.IsNullOrEmpty(field) ? field = GenerateName() : field ;
        set;
    }

    public void Reset() => Name = GenerateName();

    private string GenerateRandomLetter() => Random.Shared.GetString(_alphabet, 1);
    private static string GenerateRandomNumber() => Random.Shared.Next(0, 10).ToString();

    private string ProduceName()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(GenerateRandomLetter());
        stringBuilder.Append(GenerateRandomLetter());
        stringBuilder.Append(GenerateRandomNumber());
        stringBuilder.Append(GenerateRandomNumber());
        stringBuilder.Append(GenerateRandomNumber());
        return stringBuilder.ToString();
    }

    private  bool ValidateName(string name)
    {
        if (NameRegistry.Contains(name))
            return false;
        
        NameRegistry.Add(name);
         return true;
    }

    private string GenerateName()
    {
        string name;
        do
        {
            name = ProduceName();
        } while (!ValidateName(name));
        return name;
    }
}