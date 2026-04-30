object Isogram {

    fun isIsogram(input: String): Boolean {
        val cleanedInput = input.lowercase().filter { it.isLetter() }.toMutableList()
        return cleanedInput.size == cleanedInput.toSet().size

    }
}
