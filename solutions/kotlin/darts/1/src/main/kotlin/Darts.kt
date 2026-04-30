import kotlin.math.sqrt

object Darts {

    // target radius 10 units
    // center radius 1 unit
    // middle ring radius 5 units

    fun score(x: Number, y: Number): Int {
        val distance = calcDistance(x.toDouble(), y.toDouble())
        return when {
            distance <= 1 -> 10
            distance <= 5 -> 5
            distance <= 10 -> 1
            else -> 0
        }
    }
    fun calcDistance(x: Double, y: Double): Double {
        return sqrt(x * x + y * y)
    }
}
