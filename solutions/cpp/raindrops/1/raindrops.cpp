#include "raindrops.h"

#include <iostream>
#define EXERCISM_RUN_ALL_TESTS


namespace raindrops {

 std::string convert(int value) {
    std::string result;

    if (value % 3 == 0)
        result += "Pling";

    if (value % 5 == 0)
        result += "Plang";

     if (value % 7 == 0)
        result += "Plong";

     if (result.empty())
        return std::to_string(value);

     return result;
}

}  // namespace raindrops
