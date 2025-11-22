public class SpiralMatrix
{
    /// <summary>
    /// Generates a square matrix filled with consecutive numbers in a spiral pattern
    /// Starting from 1 in the top-left, moving right, then down, left, and up in a spiral
    /// </summary>
    /// <param name="size">The size of the square matrix (size x size)</param>
    /// <returns>A 2D array containing numbers 1 to size� arranged in spiral order</returns>
    public static int[,] GetMatrix(int size)
    {
        // Handle edge case: return empty matrix for size 0
        if (size == 0) return new int[0, 0];
        
        // matrix: The 2D integer array that will store our spiral pattern
        // Initialized with default values (0) in all positions
        var matrix = new int[size, size];
        
        // value: Current number to place in the matrix
        // Starts at 1 and increments after each placement (1, 2, 3, ..., size�)
        int value = 1;
        
        // Boundary variables: Define the rectangular "active area" that hasn't been filled yet
        // These boundaries shrink inward as we complete each side of the spiral
        
        // top: Row index of the topmost unfilled row
        // Starts at 0 (first row) and increases as we complete horizontal passes
        int top = 0;
        
        // bottom: Row index of the bottommost unfilled row  
        // Starts at size-1 (last row) and decreases as we complete horizontal passes
        int bottom = size - 1;
        
        // left: Column index of the leftmost unfilled column
        // Starts at 0 (first column) and increases as we complete vertical passes
        int left = 0;
        
        // right: Column index of the rightmost unfilled column
        // Starts at size-1 (last column) and decreases as we complete vertical passes  
        int right = size - 1;
        
        // Continue spiral filling while we still have unfilled area
        // Loop terminates when boundaries cross (top > bottom OR left > right)
        while (top <= bottom && left <= right)
        {
            // Phase 1: Fill top row from left to right
            // col: Iterator variable for column positions in current row
            for (int col = left; col <= right; col++)
                matrix[top, col] = value++; // Place current value and increment for next
            top++; // Shrink active area: move top boundary down (exclude just-filled row)
            
            // Phase 2: Fill right column from top to bottom
            // row: Iterator variable for row positions in current column
            for (int row = top; row <= bottom; row++)
                matrix[row, right] = value++; // Place current value and increment for next
            right--; // Shrink active area: move right boundary left (exclude just-filled column)
            
            // Phase 3: Fill bottom row from right to left (only if bottom row still exists)
            if (top <= bottom) // Guard: ensure we haven't already filled all rows
            {
                // col: Iterator variable for column positions, moving right to left
                for (int col = right; col >= left; col--)
                    matrix[bottom, col] = value++; // Place current value and increment for next
                bottom--; // Shrink active area: move bottom boundary up (exclude just-filled row)
            }
            
            // Phase 4: Fill left column from bottom to top (only if left column still exists)
            if (left <= right) // Guard: ensure we haven't already filled all columns
            {
                // row: Iterator variable for row positions, moving bottom to top
                for (int row = bottom; row >= top; row--)
                    matrix[row, left] = value++; // Place current value and increment for next
                left++; // Shrink active area: move left boundary right (exclude just-filled column)
            }
        }
        
        // Return the completed spiral matrix with all positions filled
        return matrix;
    }
}
