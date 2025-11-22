using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoess
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        var pile = dominoes.ToList(); // convert to list
        var piece = (0, 0);           // initialize domino tuple
        bool answer = BuildChain(pile, piece);
        return answer;
    }

    private static bool BuildChain(List<(int, int)> pile, (int, int) singleDomino)
    {
        if (pile.Count == 0 && singleDomino.Item1 == singleDomino.Item2)
            return true;

        for (int i = 0; i < pile.Count; i++)
        {
            if (i == 0)
            {
                singleDomino = (pile[i].Item1, pile[i].Item2);
            }
            else if (singleDomino.Item2 == pile[i].Item1)
                singleDomino = (singleDomino.Item1, pile[i].Item2);
            else if (singleDomino.Item2 == pile[i].Item2)
                singleDomino = (singleDomino.Item1, pile[i].Item1);
            else
                continue;
            var list = new List<(int, int)>(pile);
            list.RemoveAt(i);
            bool answer = BuildChain(list, singleDomino);
            if (answer == true)
                return answer;
        }
        return false;
    }
}