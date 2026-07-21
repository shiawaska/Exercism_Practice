#include <string>
#define EXERCISM_RUN_ALL_TESTS

namespace log_line {

    // Magic numbers and no error handling. eep
std::string message(std::string line) {
    //  [Error]: string
    auto message = line.substr( line.find(':') + 2, line.length() );
    return message;
}

std::string log_level(std::string line) {

auto level = line.substr( 1, line.find(']') - 1);
    return level;
}

std::string reformat(std::string line) {
    auto message = log_line::message(line);
    auto level = log_line::log_level(line);

std::string reformedString = message  + ' ' + '(' + level + ')';

    return reformedString;
}
}  // namespace log_line
