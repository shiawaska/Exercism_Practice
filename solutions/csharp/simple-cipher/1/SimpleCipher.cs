public class SimpleCipher
{
    // create a dictionary with the alphabet as the key and the index as the value
    private static readonly Dictionary<char, int> shiftAmountKey = Enumerable.Range('a', 26)
        .ToDictionary(
            c => (char)c,        // Key: character
            c => c - 'a'      // Value: 0-25
        );

    public SimpleCipher() => Key = Random.Shared.GetString(Enumerable.Range('a', 26).Select(i => (char)i).ToArray(), 100);

    public SimpleCipher(string key) => Key = key.ToLower();

    public string Key
    {
        get;
    }

    public string Encode(string plaintext)
    {
        var result = new char[plaintext.Length];
        
        for (int i = 0; i < plaintext.Length; i++)
        {
            var shift = FindShiftIndex(i);
            if ((plaintext[i] + shift > 'z'))
            {
                result[i] = (char)(plaintext[i] - 26 + shift);
            }
            else
            {
                result[i] = (char)(plaintext[i] + shift);
            }
        }
        return new string(result);
    }

    public string Decode(string ciphertext)
    {
        var result = new char[ciphertext.Length];
        
        for (int i = 0; i < ciphertext.Length; i++)
        {
            var shift = FindShiftIndex(i);
            if ((ciphertext[i] - shift < 'a'))
            {
                result[i] = (char)(ciphertext[i] + 26 - shift);
            }
            else
            {
                result[i] = (char)(ciphertext[i] - shift);
            }
        }
        return new string(result);
    }

    private int FindShiftIndex(int index) => shiftAmountKey[Key[index % Key.Length]];
}