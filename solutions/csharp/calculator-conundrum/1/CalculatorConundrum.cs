public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        if (operation == null)
        {
            throw new ArgumentNullException(nameof(operation), "Operation cannot be null.");
        }
        if (operation == string.Empty)
        {
            throw new ArgumentException(nameof(operation), "Operation cannot be an empty string.");
        }
            var result = ""; 
        switch (operation)
        {
            case "+":
                try
                {
                result = SimpleOperation.Addition(operand1, operand2).ToString();
                return $"{operand1} + {operand2} = {result}";
                }
                catch
                {
                    return "";
                }
            case "*":
                try
                {   result = SimpleOperation.Multiplication(operand1, operand2).ToString();
                    return $"{operand1} * {operand2} = {result}";
                }
                catch 
                {
                    return "";
                }
            case "/":
                try
                {
                    result = SimpleOperation.Division(operand1, operand2).ToString();
                    return $"{operand1} / {operand2} = {result}";
                }
                catch
                {
                    return "Division by zero is not allowed.";
                }
            default:
                throw new ArgumentOutOfRangeException(nameof(operation), $"Operation '{operation}' is not valid.");
        }
        return "";
            
    }
}
