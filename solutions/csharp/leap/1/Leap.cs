using System;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {
     double fourth = (double)year / 4.0;
     double oneHundreth = (double)year / 100.0;
     double fourHundreth = (double)year / 400.0;
        if (fourth == Math.Floor(fourth))
        {
            if (fourHundreth == Math.Floor(fourHundreth))
                return true;
            else if (oneHundreth == Math.Floor(oneHundreth))
                return false;
            return true;
        }
        else 
            return false;
    }
}