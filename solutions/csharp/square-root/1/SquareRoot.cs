public static class SquareRoot
{
    public static int Root(int baseNumber)
    {
        if (baseNumber < 0)
            throw new ArgumentException(
                "Cannot compute square root of a negative number.",
                nameof(baseNumber)
            );
        if (baseNumber == 0)
            return 0;
        var guess = Guess(baseNumber);

        while (Math.Abs(Square(guess) - baseNumber) > 1e-12)
        {
            guess = NewtonStep(baseNumber, guess);
            if (double.IsNaN(guess) || double.IsPositiveInfinity(guess) || double.IsNegativeInfinity(guess))
                return 0;
        }
        return (int)Math.Round(guess);
    }

    
    private static double Guess(int number) => Math.Max(1.0, number / 2.0);

    private static double Square(double number) => number * number;

    private static double NewtonStep( double baseNumber, double guess) => (guess + baseNumber / guess ) /2.0;
}
