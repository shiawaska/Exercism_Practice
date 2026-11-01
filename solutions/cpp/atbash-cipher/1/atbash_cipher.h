#pragma once
#include <string>

namespace atbash_cipher
{

    std::string encode(const std::string &text);
    std::string decode(const std::string &text);
    char charSwap(char c);
    void sanitizeString(std::string &text);
    void addSpaces(std::string &text);
    void encodeInternal(std::string &text);

} // namespace atbash_cipher
