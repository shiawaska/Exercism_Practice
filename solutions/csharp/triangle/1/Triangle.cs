public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
    {
        if (FailesEqualityTheorem(side1, side2, side3)) return false;
        return side1 != side2 && side2 != side3 && side3 != side1;
    }

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        if (FailesEqualityTheorem(side1, side2, side3)) return false;
        return side1 == side2 || side2 == side3 || side1 == side3;
    }

    public static bool IsEquilateral(double side1, double side2, double side3) 
    {
        if (FailesEqualityTheorem(side1, side2, side3)) return false;
        return side1 == side2 && side1 == side3;
    }
    
    public static bool FailesEqualityTheorem(double side1, double side2, double side3)
    {
        List<double> sides = [];
        
        sides.Add(side1);
        sides.Add(side2);
        sides.Add(side3);
        
        if (sides.Any(s => s == 0)) return true;
        
        List<double> sideTotals = [];
        
        sideTotals.Add(side1 + side2);
        sideTotals.Add(side3 + side2);
        sideTotals.Add(side1 + side3);
        
        return sideTotals.Any(st => st < side1 || st < side2 || st < side3) ;
        
    }
}