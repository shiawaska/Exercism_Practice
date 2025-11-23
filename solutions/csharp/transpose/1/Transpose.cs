using System.Text;

public static class Transpose
{
    public static string String(string input)
    {
        var rows = input.Split('\n');
        var longestColumn = rows.Max(row => row.Length);
        var result = new StringBuilder();

        for (int column = 0; column < longestColumn; column++)
        {
            var lineBuilder = new StringBuilder();

            int lastRowWithChar = rows.Length - 1;
            while (lastRowWithChar >= 0 && rows[lastRowWithChar].Length <= column)
                lastRowWithChar--;
            
            if (lastRowWithChar < 0)
            {
                if (column < longestColumn - 1)
                    result.Append('\n');
                continue;
            }
            
            for (int row = 0; row <= lastRowWithChar; row++)
                lineBuilder.Append(rows[row].Length > column ? rows[row][column] : ' ');
            
            result.Append(lineBuilder);

            if (column < longestColumn - 1)
                result.Append('\n');
        }

        return result.ToString();
    }
}
