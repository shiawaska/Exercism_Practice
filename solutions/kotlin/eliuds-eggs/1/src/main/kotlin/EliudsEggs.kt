object EliudsEggs {

    fun eggCount(number: Int): Int{
       val binary = number.toString(2).toCharArray()
        var count = 0;
        for (i in binary){
            if (i == '1') count++
        }
        return count


    }
}
