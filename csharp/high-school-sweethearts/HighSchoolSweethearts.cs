using System;
using System.Globalization;

public static class HighSchoolSweethearts
{
    private const int LeftNameAlignment = -29;
    private const int RightNameAlignment = 29;
    private const char Heart = (char)0x2661;
   
   
    private const int LeftNameBannerAlignment = -12;
    private const int RightNameBannerAlignment = 12;
    
    
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        return $"{studentA,RightNameAlignment} {Heart} {studentB,LeftNameAlignment}";
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        studentA = studentA.Trim().PadLeft(10);
        studentB = studentB.Trim().PadRight(10);
        var heartText = $"{studentA}  +  {studentB}";
        return DrawHeart(heartText);
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        var cultureInfo = new CultureInfo("de-DE");
        return $"{studentA} and {studentB} have been dating since {start.ToString("d", cultureInfo)} - that's {hours.ToString("N2", cultureInfo)} hours";
    }

    private static string DrawHeart(string heartText)
    {
        return
$@"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**{heartText}**
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
";

    }
    
}
