class RemoteControlCar(int speed, int batteryDrain)
{
    int batteryPercentage = 100;

    public bool BatteryDrained()
    {
        return batteryPercentage / batteryDrain <= 0 ? true : false;
    }

    public int DistanceDriven()
    {
        return speed * ((100 - batteryPercentage) / batteryDrain);
    }

    public void Drive()
    {
        if (BatteryDrained())
        {
            return;
        }
        else
        {
            batteryPercentage -= batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack(int distance)
{
    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (car.BatteryDrained() == false)
        {
            car.Drive();
            if (car.DistanceDriven() >= distance)
            {
                return true;
            }
            
        }
        return false;
    }
}
