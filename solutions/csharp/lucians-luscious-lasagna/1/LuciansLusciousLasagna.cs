class Lasagna
{
    // TODO: define the 'ExpectedMinutesInOven()' method
    public int ExpectedMinutesInOven()
    {
    int time = 40;
        return time;
    }

    // TODO: define the 'RemainingMinutesInOven()' method
    public int RemainingMinutesInOven(int PastTime)
    {
        int RemainingTime = 40 - PastTime;
            return RemainingTime;
    }
    // TODO: define the 'PreparationTimeInMinutes()' method
    public int PreparationTimeInMinutes(int Layers)
    {
        int PrepTime = 2 * Layers;
            return PrepTime;
    }

    // TODO: define the 'ElapsedTimeInMinutes()' method
    public int ElapsedTimeInMinutes(int Layers, int PastTime)
    {
        int elapsed = Layers * 2 + PastTime;  
            return elapsed;
    }
}
