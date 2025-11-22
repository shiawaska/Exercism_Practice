using System;

class RemoteControlCar
{

    public int Driven = 0; // distance measured in meters

    public int Battery = 100; // battery level measured in percentage

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {Driven} meters";
    }

    public string BatteryDisplay()
    {
        if (Battery == 0)
        {
            return "Battery empty";
        }
        return $"Battery at {Battery}%";     
    }

    public void Drive()
    {
        // every 20 meters is 1% of battery
        if (Battery > 0)
        {
            Driven += 20;
            Battery -= 1;
        }          
          
    }
}
