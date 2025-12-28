public static class Luhn
{
    public static bool IsValid(string number)
    {
        number = number.Replace(" ", string.Empty);
        foreach (var  c in number)
        {
            if (!char.IsDigit(c)) return false;
        }
        if (number.Length <= 1 || string.IsNullOrEmpty(number)) return false;

        var array = number.Reverse().Select(c => int.Parse(c.ToString())).ToList();
        for (int i = 1; i < array.Count; i += 2)
        {
            array[i] *= 2;
            if (array[i] > 9)
                array[i] -= 9;
        }
        var step1 = array.Sum();
        var step2 = step1 % 10;
        return step2 == 0;
    }
}