import java.math.BigInteger

object Board {
var board = mutableMapOf<Int, BigInteger>()
    fun getGrainCountForSquare(number: Int): BigInteger {
        require(number in 1..64) { "Input must be between 1 and 64." }
        var i = 1
        do {
            board[i] = BigInteger.valueOf(2).pow(i - 1)
            i++
        } while (i <= number)

        return board[number] ?: BigInteger.ZERO
    }

    fun getTotalGrainCount(): BigInteger {
        var sum  = BigInteger.ZERO
        var limit = board.size
        if (limit == 0) { // If class has not been setup then setup class with a full board
            getGrainCountForSquare(64)
            limit = 64
        }
        for (i in 1..limit) {
            sum += getGrainCountForSquare(i)
        }
        return sum
    }
}
