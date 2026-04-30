object ETL {
    /**
     * Transform a map of scores to a map of letters.
     * @param source a map of scores to a collection of letters
     * @return a map of letters to scores
     */
    fun transform(source: Map<Int, Collection<Char>>): Map<Char, Int> {
        val result = mutableMapOf<Char, Int>()
        for ((score, letters) in source) {
            for (letter in letters) {
                result[letter.lowercaseChar()] = score
            }
        }
        return result
    }
}
