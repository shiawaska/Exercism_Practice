public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        // convert from input base to base 10 decimal form
        // convert from input base to output base ( as array of digits )
        // use a while loop

        if (inputBase <= 1 || outputBase <= 1)
        {
            throw new ArgumentException();
        }


        if (inputDigits.Length <= 0 || inputDigits.All(digit => digit.Equals(0)))
        {
            return [0];
        }
        
        foreach (var digit in inputDigits)
        {
            if (digit < 0 || digit >= inputBase)
                throw new ArgumentException();
        }

        var digits = inputDigits.ToList();
        int total = 0;
        while (digits.Count > 0)
        {
            var depth = digits.Count - 1;
            total += digits[0] * (int)Math.Pow(inputBase, depth);
            digits.Remove(digits[0]);
        }

        while (total > 0)
        {
            var digit = total % outputBase;
            digits.Insert(0,digit);
            total /= outputBase;
            
        }
        return digits.ToArray();
    }
}
