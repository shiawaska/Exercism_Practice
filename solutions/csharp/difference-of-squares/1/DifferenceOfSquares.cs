using System;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        int sum = 0;
        for (int i = 0; i <= max ; i++)
        {
            sum = i + sum;            // add natural number to sum
        }
        sum *= sum;
        return sum;
    }

    public static int CalculateSumOfSquares(int max)
    {
     int sum = 0;
        for (int i = 0; i <= max; i++)
        {
            sum = i * i + sum;           // square natural number then add to the sum
        }        
        return sum;
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        int SQoS = CalculateSquareOfSum(max);
        int SoSQ = CalculateSumOfSquares(max);
        return SQoS - SoSQ;                     // return Square of sum minus sum of squares
    }
}