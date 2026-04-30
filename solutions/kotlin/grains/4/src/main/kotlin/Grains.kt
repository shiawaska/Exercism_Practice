import java.math.BigInteger

object Board {
    /**
     * Represents a chessboard with grains of wheat on each square.
     * Each square has a unique number, denoting the square's position on the board.
     * The first square is 1, the second is 2, the third is 3, and so on.
     * Each square has double the grain of wheat on it than the previous square,
     * starting with 1 grain on the first square.
     */
    val board: Map<Int, BigInteger> =
        (1..64).associateWith { square ->
            BigInteger.valueOf(2).pow(square - 1)
        }

    /**
     * Returns the number of grains of wheat on a square.
     * @param number An [Int] of the square number, between 1 and 64.
     * @return A [BigInteger] representing the number of grains of wheat on the given square.
     * @throws IllegalArgumentException If the square number is not between 1 and 64.
     */
    fun getGrainCountForSquare(number: Int): BigInteger {
        require(number in 1..64) { "Input must be between 1 and 64." }
        return board[number] ?: BigInteger.ZERO
    }

    /**
     * Returns the total number of grains of wheat on the board.
     * @return A [BigInteger] representing the total number of grains of wheat on the board.
     */
    fun getTotalGrainCount(): BigInteger {
        return board.values.sumOf { it }
    }
}
