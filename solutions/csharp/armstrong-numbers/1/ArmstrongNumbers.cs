public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        // Convert the number to its individual digits
        var digits = number.ToString().Select(d => int.Parse(d.ToString())).ToArray();
        // power = number of digits
        var power = digits.Length;
        // raise each digit to the power and sum them
        var total = digits.Select(d => (int)Math.Pow(d, power)).Sum();
        // check if the sum equals the original number
        return total == number;
    }
}