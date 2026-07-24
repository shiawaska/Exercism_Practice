public class Clock
{
    public int Hours { get; }
    public int Minutes { get; }

    const int minutesInHour = 60;
    const int hoursInDay = 24;
    const int minutesInDay = hoursInDay * minutesInHour;

    public Clock(int hours, int minutes)
    {
        var totalMinutes = hours * minutesInHour + minutes;
        var (temphours, tempminutes) = NormalizeTime(totalMinutes);
        Hours = temphours;
        Minutes = tempminutes;
    }

    public Clock Add(int minutesToAdd)
    {
        if (minutesToAdd < 0)
        {
            throw new ArgumentException("Minutes to add cannot be negative.");
        }
        int totalMinutes = Hours * minutesInHour + Minutes + minutesToAdd;
        var time = NormalizeTime(totalMinutes);

        return new Clock(time.hours, time.minutes);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        if (minutesToSubtract < 0)
        {
            throw new ArgumentException("Minutes to subtract cannot be negative.");
        }
        int totalMinutes = Hours * minutesInHour + Minutes - minutesToSubtract;
        var time = NormalizeTime(totalMinutes);

        return new Clock(time.hours, time.minutes);
    }

    public override string ToString() =>  $"{Hours:D2}:{Minutes:D2}";
    

    private (int hours, int minutes) NormalizeTime(int totalMinutes)
    {
        while (totalMinutes >= minutesInDay || totalMinutes < 0)
        {
            if (totalMinutes >= minutesInDay)
            {
                totalMinutes -= minutesInDay;
            }
            else
            {
                totalMinutes += minutesInDay;
            }
        }
        int newHours = totalMinutes / minutesInHour;
        int newMinutes = totalMinutes % minutesInHour;
        return (newHours, newMinutes);
    }

    public override bool Equals(object? o)
    {
        var match = o is Clock other && Hours == other.Hours && Minutes == other.Minutes;
        return match;

    } 
    
    public override int GetHashCode() => HashCode.Combine(Hours,Minutes);
}

