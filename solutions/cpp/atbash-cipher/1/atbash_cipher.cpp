#include "atbash_cipher.h"
#include <string>
#include <cctype>

namespace atbash_cipher
{

    const std::string alphabet = "abcdefghijklmnopqrstuvwxyz";

    std::string
    encode(const std::string &text)
    {
        std::string encodedString = text;
        sanitizeString(encodedString);
        encodeInternal(encodedString);
        addSpaces(encodedString);
        return encodedString;
    }

    std::string decode(const std::string &text)
    {
        std::string decodedString;
        decodedString = text;
        sanitizeString(decodedString);
        encodeInternal(decodedString);
        return decodedString;
    }

    /// @brief Swaps a character with its corresponding character in the Atbash cipher
    /// @param c the target character to be swapped
    /// @return the swapped character or null character if not found
    char charSwap(char c)
    {
        c = static_cast<char>(std::tolower(c));
        const auto index = alphabet.find(c);
        if (index == std::string::npos)
            return '\0';

        return alphabet[alphabet.size() - 1 - index];
    }

    /// @brief Sanitizes the input string by removing non-alphanumeric characters and converting to lowercase
    /// @param text Reference to the string to be sanitized
    void sanitizeString(std::string &text)
    {
        auto stringLength = text.size();
        for (std::string::size_type i = 0; i < stringLength; ++i)
        {
            if (std::isalnum(text[i]))
            {
                text[i] = std::tolower(text[i]);
            }
            else
            {
                text.erase(i, 1);
                --i;
                --stringLength;
            }
        }
    }

    /// @brief Adds spaces to the string every 5 characters
    /// @param text Text input to add spaces to
    void addSpaces(std::string &text)
    {
        for (std::string::size_type i = 5; i < text.size(); i += 6)
        {
            text.insert(i, " ");
        }
    }

    void encodeInternal(std::string &text)
    {
        for (std::string::size_type i = 0; i < text.size(); ++i)
        {
            char c = charSwap(text[i]);
            if (c == '\0')
                continue;
            text[i] = c;
        }
    }
}