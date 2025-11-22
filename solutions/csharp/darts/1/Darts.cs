using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        // convert any negatives into positives
       double _x = Math.Abs(x);
        double _y = Math.Abs(y);
        
        // if withing inner circle
       if (_x + _y <= 1.4)
           return 10;
        // if within middle circle
        if (_x + _y <= 7)
            return 5;
        // if within outer circle
        if (_y + _x <= 14)
            return 1;
        // else its not on the board
        else 
            return 0;
    }
}
