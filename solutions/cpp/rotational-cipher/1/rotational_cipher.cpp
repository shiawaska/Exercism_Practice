#include "rotational_cipher.h"

namespace rotational_cipher
{

    std::string rotate(const std::string input, int rotation_factor)
    {
        int letter_shift = ((rotation_factor % 26) + 26) % 26;
        int number_shift = ((rotation_factor % 10) + 10) % 10;

        std::string result;
        for (char c : input)
        {
            if (std::isalpha(c))
            {
                char base = std::islower(c) ? 'a' : 'A';
                c = (c - base + letter_shift) % 26 + base;
            }
            else if (std::isdigit(c))
            {
                c = (c - '0' + number_shift) % 10 + '0';
            }
            result += c;
        }
        return result;
    }
}
