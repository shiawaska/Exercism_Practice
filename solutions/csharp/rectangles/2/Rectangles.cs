public static class Rectangles
{
    //     Identify all corners (+) in the grid and store their positions in `corners`.
    //      Find pairs of corners (`topLeftCornerRow`, `topLeftCornerCol`) and (`bottomRightCornerRow`, `bottomRightCornerCol`) that can serve as the top-left and bottom-right of a rectangle.
    //      Verify that the sides between these corners (horizontal '-' and vertical '|') are complete,
    //      meaning all required edges are present and connect the corners.
    //      Ensure all four corners of the rectangle are '+' and all sides are intact.
        public static int Count(string[] rows)
        {
            if (rows.Length == 0)
                return 0;
            
            int count = 0;
            int height = rows.Length;
            int width = rows[0].Length;

            // Find all '+' positions
            var corners = new List<(int, int)>();
            for (int r = 0; r < height; r++)
            for (int c = 0; c < width; c++)
                if (rows[r][c] == '+')
                    corners.Add((r, c));

            // Check all pairs of corners
            foreach (var (topLeftCornerRow, topLeftCornerCol) in corners)
            {
                foreach (var (bottomRightCornerRow, bottomRightCornerCol) in corners)
                {
                    // if BottomRightCornerRow > TopLeftCornerRow and BottomRightCornerCol > TopLeftCornerCol, then BottomRightCornerRow is above TopLeftCornerRow and BottomRightCornerCol is to the right of TopLeftCornerCol
                    if (bottomRightCornerRow > topLeftCornerRow && bottomRightCornerCol > topLeftCornerCol)
                    {
                        // Check the other two corners
                        if (rows[topLeftCornerRow][bottomRightCornerCol] == '+' && rows[bottomRightCornerRow][topLeftCornerCol] == '+')
                        {
                            // Check horizontal and vertical sides
                            bool valid = true;
                            // Check that the top edge between (TopLeftCornerRow, TopLeftCornerCol) and (TopLeftCornerRow, BottomRightCornerCol) is made of '-' or '+'
                            for (int cc = topLeftCornerCol + 1; cc < bottomRightCornerCol; cc++)
                                if (rows[topLeftCornerRow][cc] != '-' && rows[topLeftCornerRow][cc] != '+') valid = false;

                            // Check that the bottom edge between (BottomRightCornerRow, TopLeftCornerCol) and (BottomRightCornerRow, BottomRightCornerCol) is made of '-' or '+'
                            for (int cc = topLeftCornerCol + 1; cc < bottomRightCornerCol; cc++)
                                if (rows[bottomRightCornerRow][cc] != '-' && rows[bottomRightCornerRow][cc] != '+') valid = false;

                            // Check that the left edge between (TopLeftCornerRow, TopLeftCornerCol) and (BottomRightCornerRow, TopLeftCornerCol) is made of '|' or '+'
                            for (int rr = topLeftCornerRow + 1; rr < bottomRightCornerRow; rr++)
                                if (rows[rr][topLeftCornerCol] != '|' && rows[rr][topLeftCornerCol] != '+') valid = false;

                            // Check that the right edge between (TopLeftCornerRow, BottomRightCornerCol) and (BottomRightCornerRow, BottomRightCornerCol) is made of '|' or '+'
                            for (int rr = topLeftCornerRow + 1; rr < bottomRightCornerRow; rr++)
                                if (rows[rr][bottomRightCornerCol] != '|' && rows[rr][bottomRightCornerCol] != '+') valid = false;

                            if (valid) count++;
                        }
                    }
                }
            }
            return count;
        }
}