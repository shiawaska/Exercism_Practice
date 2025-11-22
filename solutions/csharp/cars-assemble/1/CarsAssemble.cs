using System;

static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        // throw new NotImplementedException("Please implement the (static) AssemblyLine.SuccessRate() method");
        if (speed == 0){
            return 0.0;       
        }
        if (speed > 0 && speed < 5){
            return 1.0;
        }
        if (speed > 4 && speed < 9){
            return 0.9;
        }
        if (speed == 9){
            return 0.8;
        }
        if (speed == 10){
            return 0.77;
        }
        else {
            throw new Exception("invalid input!");
        }
    }
    
    public static double ProductionRatePerHour(int speed)
    {
    // throw new NotImplementedException("Please implement the (static) AssemblyLine.ProductionRatePerHour() method");
        double prph = speed * 221;
        prph = prph * SuccessRate(speed);
        return prph;
    }
    

    public static int WorkingItemsPerMinute(int speed)
    {
        // throw new NotImplementedException("Please implement the (static) AssemblyLine.WorkingItemsPerMinute() method");
       double sum =  ProductionRatePerHour(speed);       
       sum = sum / 60;
        int production =(int) sum;        
        return production;
    }
}
