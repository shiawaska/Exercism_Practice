#include "rotational_cipher.h"

#include <cctype>

namespace rotational_cipher
{

    std::string rotate(const std::string input, int rotation_factor)
    {
        int letter_shift = ((rotation_factor % 26) + 26) % 26;
        std::string result;
        for (char c : input)
        {
            const auto unsigned_c = static_cast<unsigned char>(c);
            if (std::isalpha(unsigned_c))
            {
                char base = std::islower(unsigned_c) ? 'a' : 'A';
                c = (c - base + letter_shift) % 26 + base;
            }
            result += c;
        }
        return result;
    }
}
