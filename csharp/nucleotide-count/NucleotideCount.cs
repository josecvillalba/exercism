using System;
using System.Collections.Generic;

public class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {

        var dictionary = new Dictionary<char, int>()
        {
            {'A', 0},
            {'C', 0},
            {'G', 0},
            {'T', 0}
        };

        foreach (var c in sequence)
        {
            switch (c)
            {
                case 'A':
                case 'C':
                case 'G':
                case 'T':
                    dictionary[c]++;
                    break;
                default:
                    throw new ArgumentException("Invalid character found in sequence");
            }
        }

        return dictionary;
    }
}