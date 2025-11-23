using System.Data;

public class Matrix
{
    private readonly string[] _rows;
    private readonly string[] _columns;
    public Matrix(string input)
    {
         _rows = input
            .Split(['\n'], StringSplitOptions.RemoveEmptyEntries)
            .Select(r => r.Trim())
            .ToArray();
         
         _columns = GenerateColumns(_rows);
    }

    public int[] Row(int row) => _rows[row - 1].Split(' ').Select(int.Parse).ToArray();

    public int[] Column(int col) => _columns[col - 1].Split(' ').Select(int.Parse).ToArray();

    private static string[] GenerateColumns(string[] rows)
    {
        if (rows == null || rows.Length == 0)
            return Array.Empty<string>();

        var splitRows = rows
            .Select(r => r.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .ToArray();

        int columnCount = splitRows[0].Length;

        for (int i = 1; i < splitRows.Length; i++)
        {
            if (splitRows[i].Length != columnCount)
                throw new ArgumentException("All rows must have the same number of columns.", nameof(rows));
        }

        var columns = new string[columnCount];
        for (int c = 0; c < columnCount; c++)
        {
            columns[c] = string.Join(" ", splitRows.Select(r => r[c]));
        }

        return columns;
    }}