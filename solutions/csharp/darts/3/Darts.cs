using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        // convert coordinates into a distance from the center
     double Distance = Math.Sqrt( x * x + y * y);
        // radius for each circle
        int InnerCircle = 1;
        int MiddleCircle = 5;
        int OuterCircle = 10;

        if (Distance <= InnerCircle)
            return 10;
        
        if (Distance <= MiddleCircle)
            return 5;
        
        if (Distance <= OuterCircle)
            return 1;
        
        else 
            return 0;
    }
}
