using System.Text;

public class RailFenceCipher(int rails)
{
    private enum Direction
    {
        Downward,
        Upward,
    }

    public string Encode(string input)
    {
        var rail = 0;
        var direction = Direction.Downward;

        var railsArray = new StringBuilder[rails];
        for (int i = 0; i < rails; i++)
            railsArray[i] = new StringBuilder();

        for (int i = 0; i <= input.Length - 1; i++)
        {
            railsArray[rail].Append(input[i]);
            if (rail == 0)
                direction = Direction.Downward;
            if (rail == rails - 1)
                direction = Direction.Upward;
            if (direction == Direction.Downward)
                rail++;
            if (direction == Direction.Upward)
                rail--;
        }
        var result = new StringBuilder();
        foreach (var sb in railsArray)
            result.Append(sb);

        return result.ToString();
    }

    public string Decode(string input)
    {
        var railLengths = new int[rails];
        var rail = 0;
        var direction = Direction.Downward;
    
        for (int i = 0; i < input.Length; i++)
        {
            railLengths[rail]++;
            if (rail == 0)
                direction = Direction.Downward;
            if (rail == rails - 1)
                direction = Direction.Upward;
            if (direction == Direction.Downward)
                rail++;
            else
                rail--;
        }
        var railsArray = new string[rails];
        var index = 0;
        for (int i = 0; i < rails; i++)
        {
            railsArray[i] = input.Substring(index, railLengths[i]);
            index += railLengths[i];
        }
        var result = new StringBuilder();
        var railIndices = new int[rails];
        rail = 0;
        direction = Direction.Downward;
    
        for (int i = 0; i < input.Length; i++)
        {
            result.Append(railsArray[rail][railIndices[rail]++]);
            if (rail == 0)
                direction = Direction.Downward;
            if (rail == rails - 1)
                direction = Direction.Upward;
            if (direction == Direction.Downward)
                rail++;
            else
                rail--;
        }

        return result.ToString();
    }
}
