object Bob {
    fun hey(input: String): String {
        return buildReturn(determineInputType(input))
    }

    enum class InputType {
        SHOUTING,
        QUESTION,
        `YELLING QUESTION`,
        SILENCE,
        OTHER
    }

    fun determineInputType(input: String): InputType {
        val trimmedInput = input.filter { it.isLetter() }
        return when {
            input.isBlank() -> InputType.SILENCE
            trimmedInput.all { it.isUpperCase() } && !trimmedInput.isBlank() && input.last() == '?' -> InputType.`YELLING QUESTION`
            trimmedInput.all { it.isUpperCase() } && !trimmedInput.isBlank() -> InputType.SHOUTING
            input.trim().endsWith("?") && !input.isBlank() -> InputType.QUESTION
            else -> InputType.OTHER
        }
    }

    fun buildReturn(input: InputType) = when (input) {
        InputType.SHOUTING -> "Whoa, chill out!"
        InputType.QUESTION -> "Sure."
        InputType.`YELLING QUESTION` -> "Calm down, I know what I'm doing!"
        InputType.SILENCE -> "Fine. Be that way!"
        InputType.OTHER -> "Whatever."
    }
}

