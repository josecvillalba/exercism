using System;
using System.Linq;
using System.Runtime.CompilerServices;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string s, string d) => s.Split(d).Last();
    public static string SubstringBetween(this string s, string c1, string c2) => s.Split(c2).First().Split(c1).Last();
    
    
/*    
    public static string SubstringAfter(this string str, string pattern)
    {
        var index = str.IndexOf(pattern, StringComparison.Ordinal);
        index += pattern.Length;
        return str[index..];
    }
    
    public static string SubstringBetween(this string str, string begin, string end)
    {
        var index1 = str.IndexOf(begin, StringComparison.Ordinal);
        var index2 = str.IndexOf(end, StringComparison.Ordinal);

        index1 += begin.Length;

        return str.Substring(index1, index2-index1);

    } 
*/

    public static string Message(this string str) => str.SubstringAfter(": ");
    
    public static string LogLevel(this string str) => str.SubstringBetween("[", "]");
}