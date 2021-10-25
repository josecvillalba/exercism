using System;
using System.Linq;
using System.Text.RegularExpressions;

public class LogParser
{
    
    public bool IsValidLine(string text)
    {
        return Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FIL)\].*$");
    }

    public string[] SplitLogLine(string text) => Regex
        .Split(text, @"<.+?>");
    
    public int CountQuotedPasswords(string lines) => Regex
        .Matches(lines, @".*[^\""]*password[^\""]*.*", RegexOptions.IgnoreCase | RegexOptions.Multiline)
        .Count;

    public string RemoveEndOfLineText(string line) => Regex
        .Replace(line, @"end-of-line\d+", string.Empty);
    
    public string[] ListLinesWithPasswords(string[] lines) => 
        (
            from line in lines
            let match = Regex.Match(line, @"password[^\s]+", RegexOptions.IgnoreCase)
            select match.Success ? $"{match.Value}: {line}" : $"--------: {line}"
        )
        .ToArray();}
