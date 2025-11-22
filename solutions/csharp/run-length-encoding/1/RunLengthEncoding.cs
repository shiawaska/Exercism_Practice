public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        var encodedString = new System.Text.StringBuilder();
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        for (int i = 0; i < input.Length;)
        {
          var count = charCounter(input[i], i, input);
            if (count != 1)
            {
                encodedString.Append((count).ToString());
            }
            encodedString.Append(input[i].ToString());            
                i += count;
        }
        return encodedString.ToString();
    }

    public static string Decode(string input)
    {
        var decodedString = new System.Text.StringBuilder();
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }
        var count = new System.Text.StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsDigit(input[i]))
            {
                count.Append(input[i]);
            }
            else
            {
                if (count.Length > 0)
                {
                    int repeatCount = int.Parse(count.ToString());
                    decodedString.Append(new string(input[i], repeatCount));
                    count.Clear();
                }
                else
                {
                    decodedString.Append(input[i]);
                }
            }
        }
            return decodedString.ToString();
    }

    public static int charCounter(char primary, int index, string input)
    {
        int count = 1;
        index++;
        while (index < input.Length && primary == input[index]) {
            count++;
            index++;
        }
        return count;
    }
}
