public class SpaceAge
{
    private int _seconds;
    private const double EarthYearInSeconds = 31557600.0;

    public SpaceAge(int seconds)
    {
        _seconds = seconds;
    }


    public double OnEarth()
    {
        return _seconds / (EarthYearInSeconds *  1.0);
    }

    public double OnMercury()
    {
        return _seconds / (EarthYearInSeconds * 0.2408467);
    }

    public double OnVenus()
    {
        return _seconds / (EarthYearInSeconds * 0.61519726);
    }

    public double OnMars()
    {
        return _seconds / (EarthYearInSeconds * 1.8808158);
    }

    public double OnJupiter()
    {
        return _seconds / (EarthYearInSeconds * 11.862615);
    }

    public double OnSaturn()
    {
        return _seconds / (EarthYearInSeconds * 29.447498);
    }

    public double OnUranus()
    {
        return _seconds / (EarthYearInSeconds * 84.016846);
    }

    public double OnNeptune()
    {
        return _seconds / (EarthYearInSeconds * 164.79132);
    }
    
   
}