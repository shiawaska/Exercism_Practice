object CollatzCalculator {
    fun computeStepCount(start: Int): Int {
        if (start < 1) {
            throw IllegalArgumentException("Input must be greater than zero")
        }
        var start = start
        var steps = 0
        while (start != 1) {
            if (start % 2 == 0) {
                start /= 2
            } else {
                start = 3 * start + 1
            }
            steps++
        }
        return steps
    }
}

