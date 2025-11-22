using System;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {     
        if (year % 4 == 0)  // divisable by 4
        {
            if (year % 400 == 0)  // divisable by 400
                return true;
            else if (year % 100 == 0)  // divisable by 100
                return false;
            return true;
        }
        else 
            return false;
    }
}