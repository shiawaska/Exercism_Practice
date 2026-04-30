fun reverse(input: String): String {
    var reversed = mutableListOf<Char>()

    for (char in input)
    {
        reversed.add(0,char)
    }
    return reversed.joinToString("")
}
