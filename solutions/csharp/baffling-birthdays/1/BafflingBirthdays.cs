public static class BafflingBirthdays{

    public static DateOnly[] RandomBirthdates(int numberOfBirthdays)
    {
        var birthdays = new DateOnly[numberOfBirthdays];

        for (int i = 0; i < numberOfBirthdays; i++)
        {
            var year = Random.Shared.Next(1900, 2023);

            while (DateTime.IsLeapYear(year))
            {
                year = Random.Shared.Next(1900, 2023);
            }
                        

            var month = Random.Shared.Next(1, 13);
            var day = Random.Shared.Next(1, DateTime.DaysInMonth(year, month) + 1);
            
            birthdays[i] = new DateOnly(year, month, day);
        }


        return birthdays;
    }

    public static bool SharedBirthday(DateOnly[] birthdays)
    {
        HashSet<(int Month, int Day)> uniqueBirthdays = [];

        return birthdays.Any(birthday => !uniqueBirthdays.Add((birthday.Month, birthday.Day)));
    }

    public static double EstimatedProbabilityOfSharedBirthday(int numberOfBirthdays)
    {
        const double daysInYear = 365;

        if (numberOfBirthdays <= 1)
        {
            return 0.0;
        }

        double probabilityOfNoSharedBirthday = 1.0;
        for (int i = 0; i < numberOfBirthdays; i++)
        {
            probabilityOfNoSharedBirthday *= (daysInYear - i) / daysInYear;
        }

        return (1.0 - probabilityOfNoSharedBirthday) * 100.0;
    }
}
