public static class Rectangles
{
        //      Identify all corners (+) in the grid.
        //     Find pairs of corners that can serve as the top-left and bottom-right of a rectangle.
        //     Verify that the sides between these corners (horizontal - and vertical |) are complete,
        //      meaning all required edges are present and connect the corners.
        //     Ensure all four corners of the rectangle are + and all sides are intact.
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
            foreach (var (r1, c1) in corners)
            {
                foreach (var (r2, c2) in corners)
                {
                    // if r2 > r1 and c2 > c1, then r2 is above r1 and c2 is to the right of c1
                    if (r2 > r1 && c2 > c1)
                    {
                        // Check other two corners
                        if (rows[r1][c2] == '+' && rows[r2][c1] == '+')
                        {
                            // Check horizontal and vertical sides
                            bool valid = true;
                            // Check that the top edge between (r1, c1) and (r1, c2) is made of '-' or '+'
                            for (int cc = c1 + 1; cc < c2; cc++)
                                if (rows[r1][cc] != '-' && rows[r1][cc] != '+') valid = false;

                            // Check that the bottom edge between (r2, c1) and (r2, c2) is made of '-' or '+'
                            for (int cc = c1 + 1; cc < c2; cc++)
                                if (rows[r2][cc] != '-' && rows[r2][cc] != '+') valid = false;

                            // Check that the left edge between (r1, c1) and (r2, c1) is made of '|' or '+'
                            for (int rr = r1 + 1; rr < r2; rr++)
                                if (rows[rr][c1] != '|' && rows[rr][c1] != '+') valid = false;

                            // Check that the right edge between (r1, c2) and (r2, c2) is made of '|' or '+'
                            for (int rr = r1 + 1; rr < r2; rr++)
                                if (rows[rr][c2] != '|' && rows[rr][c2] != '+') valid = false;

                            if (valid) count++;
                        }
                    }
                }
            }
            return count;
        }
}