using System;
using System.Linq;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException("Both strands must be the same lenght");
        }

        return firstStrand.Where((t, i) => t != secondStrand[i]).Count();
    }
}