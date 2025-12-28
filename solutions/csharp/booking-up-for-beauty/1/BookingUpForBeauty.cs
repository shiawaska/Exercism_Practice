using System.Data;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        // possible input strings:
        // "7/25/2019 13:45:00"
        // "June 3, 2019 11:30:00"
        // "Thursday, December 5, 2019 09:00:00"
        return new DateTime(Year(appointmentDateDescription),Month(appointmentDateDescription), Day(appointmentDateDescription),Hour(appointmentDateDescription),Minute(appointmentDateDescription),Second(appointmentDateDescription));
        
    }

    private static int Year(string s)
    {
        if (string.IsNullOrEmpty(s)) throw new ArgumentException("Invalid date string");
        // year is the only 4 continuous digits of the string
        int digitCount = 0;
        for (int i =0; i < s.Length; i++)
        {
            if (Char.IsDigit(s[i]))
            {
             digitCount++;
                // return int.Parse(s.Substring(i, 4));
            }
            else
            {
                digitCount = 0;
            }
            if (digitCount == 4) return int.Parse(s.Substring(i - 3, 4));
        }
        throw new ArgumentException(); 
    }

    private static int Month(string s)
    {
        // month is either
        // the first # followed by a /
        // or spelled out
        string[] months =
        [
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        ];
        if (Char.IsDigit(s[0]))
        {
            // Extract all leading digits up to the slash
            int endIndex = s.IndexOf('/');
            if (endIndex > 0)
            {
                return int.Parse(s.Substring(0, endIndex));
            }
        }

        foreach (string month in months)
        {
                if (s.Contains(month)) return Array.IndexOf(months, month) + 1;
        }
        throw new ArgumentException();
        
        
    }

    private static int Day(string s)
    {
        var slashes = s.Split('/');
        if (slashes.Length > 1)
        {
            // Extract digits from slashes[1]
            string dayPart = new string(slashes[1].TakeWhile(char.IsDigit).ToArray());
            return int.Parse(dayPart);
        }
        
        var commas = s.Split(',');
        if (commas.Length > 1)
        {
            string[] parts = commas[0].Trim().Split(' ');
            if (parts.Length > 1 && int.TryParse(parts[parts.Length - 1], out int day))
            {
                return day;
            }
        }
        
        var parts2 = s.Split(' ');
        foreach (var part in parts2)
        {
            string cleanPart = part.TrimEnd(',');
            if (int.TryParse(cleanPart, out int day))
                return day;
        }
        throw new ArgumentException();
    }
    

    private static int Hour(string s)
    {
        var match = Regex.Match(s, @"\b(\d{1,2}):\d{2}:\d{2}\b");
        if (match.Success)
        {
            return int.Parse(match.Groups[1].Value);
        }
        throw new ArgumentException();
    }

    private static int Minute(string s)
    {
        var match = Regex.Match(s, @"\b\d{1,2}:(\d{2}):\d{2}\b");
        if (match.Success)
        {
            return int.Parse(match.Groups[1].Value);
        }
        throw new ArgumentException();
    }
    
    private static int Second(string s)
    {
        var match = Regex.Match(s, @"\b\d{1,2}:\d{2}:(\d{2})\b");
        if (match.Success)
        {
            return int.Parse(match.Groups[1].Value);
        }
        throw new ArgumentException();
    }


    public static bool HasPassed(DateTime appointmentDate)
    {
        return appointmentDate < DateTime.Now;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        var noon = TimeOnly.MinValue.Hour + 12;
        var afterAfterNoon = TimeOnly.MinValue.Hour + 18;
        return appointmentDate.Hour >= noon && appointmentDate.Hour < afterAfterNoon;
    }

    public static string Description(DateTime appointmentDate)
    { ;
        return $"You have an appointment on {appointmentDate}.";
    }

    public static DateTime AnniversaryDate()
    {
        return new(DateTime.Now.Year, 9, 15);
    }
}
