class Leap {
  /**
   * Determines if the given year is a leap year.
   * A leap year is defined as:
   * - It is divisible by 4, but not divisible by 100, OR
   * - It is divisible by 400.
   */
  bool leapYear(int year) {
    bool divisibleBy4 = year % 4 == 0;
    bool divisibleBy100 = year % 100 == 0;
    bool divisibleBy400 = year % 400 == 0;

    return (divisibleBy4 && !divisibleBy100) || divisibleBy400;
  }
}
