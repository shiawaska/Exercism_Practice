import java.math.BigInteger

object Board {
    val board: Map<Int, BigInteger> =
        (1..64).associateWith { square ->
            BigInteger.valueOf(2).pow(square - 1)
        }
    fun getGrainCountForSquare(number: Int): BigInteger {
        require(number in 1..64) { "Input must be between 1 and 64." }
        return board[number] ?: BigInteger.ZERO
    }

    fun getTotalGrainCount(): BigInteger {
       return board.values.sumOf { it }
    }
}
