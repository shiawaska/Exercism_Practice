


public interface IRemoteControlCar
{
    public void Drive();
    public int DistanceTravelled { get; }
}

public class ProductionRemoteControlCar :IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }
    
    /// <summary>
    /// Compares the number of victories of the current car to the other car.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(ProductionRemoteControlCar? other)
    {
        return other == null ? 1 : NumberOfVictories.CompareTo(other.NumberOfVictories);
    }

}

public class ExperimentalRemoteControlCar :IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
       var value =  prc1.CompareTo(prc2);
       if (value > 0)
           return [prc2, prc1];
       return [prc1, prc2];
    }
}
