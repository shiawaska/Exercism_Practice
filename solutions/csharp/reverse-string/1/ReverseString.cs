public static class ReverseString
{
    public static string Reverse(string input)
    {
        if (input == null)
            return string.Empty;
        var result = new System.Text.StringBuilder();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            result.Append(input[i]);
        }
        return result.ToString();
    }
}