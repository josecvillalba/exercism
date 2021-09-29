using System;

static class LogLine
{
    public static string Message(string logLine)
    {
        int pos = logLine.LastIndexOf(':') + 1;
        string msg = logLine[pos..].Trim();

        return msg;
    }

    public static string LogLevel(string logLine)
    {
        int start = logLine.IndexOf('[') + 1;
        int end = logLine.IndexOf(']') - 1;

        return logLine.Substring(start, end - start + 1).Trim().ToLower();
    }

    public static string Reformat(string logLine)
    {
        return Message(logLine) + " (" + LogLevel(logLine) + ")";
    }
}
