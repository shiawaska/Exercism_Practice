// INFO: Headers from the standard library should be inserted at the top via
// #include <LIBRARY_NAME>
#define EXERCISM_RUN_ALL_TESTS
#include <cmath>
#include <iostream>

// daily_rate calculates the daily rate given an hourly rate
double daily_rate(double hourly_rate) {
    // 8 hours per day
    return hourly_rate * 8;
}
double convertFactor(double discount) {
    return 1.0 -discount / 100;
}

// apply_discount calculates the price after a discount
double apply_discount(double before_discount, double discount) {
    return before_discount * convertFactor(discount);
}

// monthly_rate calculates the monthly rate, given an hourly rate and a discount
// The returned monthly rate is rounded up to the nearest integer.
int monthly_rate(double hourly_rate, double discount) {
    // 22days
    auto dayRate = daily_rate(hourly_rate);
    auto monthRate = dayRate * 22;
    auto totalAfterDiscount = apply_discount(monthRate, discount);
    // discount.
    return static_cast<int>(std::ceil(totalAfterDiscount));
}

// days_in_budget calculates the number of workdays given a budget, hourly rate,
// and discount The returned number of days is rounded down (take the floor) to
// the next integer.
int days_in_budget(int budget, double hourly_rate, double discount) {
    auto dayRate = daily_rate(hourly_rate);
    auto dayRateAfterDiscount = apply_discount(dayRate, discount);

    return  budget / static_cast<int>(std::floor(dayRateAfterDiscount));

    // discount, and calculates how many complete days of work that covers.
    return 0;
}
