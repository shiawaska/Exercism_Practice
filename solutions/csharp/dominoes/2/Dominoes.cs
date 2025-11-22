using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        var pile = dominoes.ToList(); // convert to list
        bool answer = BuildChain(pile, (0, 0)); // call function with a pile of dominoes and a "blank space"
        return answer;
    }

    private static bool BuildChain(List<(int, int)> pile, (int, int) domino)
    {
        if (pile.Count == 0 && domino.Item1 == domino.Item2) // base statement (empty pile and start/finish match)
            return true;

        for (int i = 0; i < pile.Count; i++) 
        {
            if (domino == (0, 0)) // if first domino
                domino = pile[i]; // set first domino 

            else if (domino.Item2 == pile[i].Item1) // if domino matches
                domino = (domino.Item1, pile[i].Item2); // set domino

            else if (domino.Item2 == pile[i].Item2) // if flipped domino matches
                domino = (domino.Item1, pile[i].Item1); // set domino

            else
                continue;
            var list = new List<(int, int)>(pile);  // (if matche found) make a copy of the pile
            list.RemoveAt(i);                   // remove matched domino (first domino is considered a matched domino)
            bool answer = BuildChain(list, domino);  //  call function with new list (pile - matched dominoes)
            if (answer == true)
                return answer;
        }
        return false;
    }
}