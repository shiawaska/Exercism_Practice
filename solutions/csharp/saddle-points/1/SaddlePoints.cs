public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        // result variable
        var saddlePoints = new List<(int, int)>();
        // x vertices
        int rows = matrix.GetLength(0);
        // y vertices
        int cols = matrix.GetLength(1);
        
        // each rows larges value
        int[] rowMax = new int[rows];
        // each columns smallest value
        int[] colMin = new int[cols];
        
        // initialize to min and max values
        for (int r = 0; r < rows; r++)
            rowMax[r] = int.MinValue;
        for (int c = 0; c < cols; c++)
            colMin[c] = int.MaxValue;

        // iterate through matrix saving the max and min values
        for (int currentRow = 0; currentRow <= rows - 1; currentRow++)
        {
            for (int currentColumn = 0; currentColumn <= cols - 1; currentColumn++)
            {
                rowMax[currentRow] = Math.Max(rowMax[currentRow], matrix[currentRow, currentColumn]);
                colMin[currentColumn] = Math.Min(colMin[currentColumn], matrix[currentRow, currentColumn]);
            }
        }
        
        // iterate through matrix and check if max and min values are equal, If so add to result
        for (int currentRow = 0; currentRow <= rows - 1; currentRow++)
        {
            for (int currentColumn = 0; currentColumn <= cols - 1; currentColumn++)
            {
                if (matrix[currentRow, currentColumn] == rowMax[currentRow] && matrix[currentRow, currentColumn] == colMin[currentColumn])
                    saddlePoints.Add((currentRow + 1, currentColumn + 1));
            }
        }
        
        return saddlePoints;
    }
}
