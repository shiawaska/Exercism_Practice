using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class RnaTranscription
{
    public static string ToRna(string strand)
    {
        var Rna = new StringBuilder();
        foreach (var t in strand)
        {
            char r = convert(t);
            Rna.Append(r);
        }
        return Rna.ToString();
    }

    public static char convert(char t)
    {
        switch (t)
        {
            case 'G':
                return 'C';
            case 'C':
                return 'G';
            case 'T':
                return 'A';
            case 'A':
                return 'U';
        }
        throw new InvalidDataException("Provided value must be a DNA nucleotide G,C,T, or A");
    }

    // G -> C
    // C -> G
    // T -> A
    // A -> U
}
