using System;
using System.Collections.Generic;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        // initialize variables
        int a = 0;
        int b = 0;
        int c = 0;
        // create a list to store the answers
        List<(int, int, int)> answers = new List<(int, int, int)>();

        // loop through the possible values of a
        while (a < sum/3) // a is always less than sum/3
        {
            a++; //
            b = a + 1; // b is always greater than a
            while (b < sum/2) // b is always less than sum/2
            {
                
                c = sum - a - b; // c is the remaining value

                if (a * a + b * b == c * c && a < b && b < c) /// check if the values are pythagorean triplets
                {
                    answers.Add((a, b, c));
                }
                b++; 
            }
            
        }
        return answers;
    }
}