using System;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        int[] BirdCount = { 0,2,5,3,7,8,4};
        return BirdCount;
    }

    public int Today()
    {
        return this.birdsPerDay[6];
    }

    public void IncrementTodaysCount()
    {
        this.birdsPerDay[6] += 1;
    }

    public bool HasDayWithoutBirds()
    {
        foreach (var day in birdsPerDay)
            if (day == 0)
                return true;
            
        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int _Count = 0;
        for (int i = 0; i < numberOfDays; i++)
             _Count += birdsPerDay[i];
        return _Count;
            
    }

    public int BusyDays()
    {
        int _Count = 0;
            foreach (var day in birdsPerDay)
                if (day >= 5)
                    _Count += 1;
        return _Count;
    }
}
