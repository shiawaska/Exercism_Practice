data class Year(val year: Int) {

    /**
     * @return true if the given year is a leap year
     * @see <a href="https://en.wikipedia.org/wiki/Leap_year">Leap year</a>
     * Note: A leap year is a year divisible by 4, except for years divisible by 100 unless they are also divisible by 400.
     */

    val isLeap: Boolean = year % 4 == 0 && (year % 100 != 0 || year % 400 == 0)
}
