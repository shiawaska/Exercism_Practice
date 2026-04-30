class Dna(dnaString: String) {
    val defaultCounts = mapOf('A' to 0, 'C' to 0, 'G' to 0, 'T' to 0)
    val str: String = dnaString.uppercase()

    init {
        if (str.any { it !in "ACGT" }) {
            throw IllegalArgumentException("Invalid DNA sequence")
        }
    }

    val nucleotideCounts: Map<Char, Int>
        get() {
            return defaultCounts + str.groupingBy { it }.eachCount()
        }
}
