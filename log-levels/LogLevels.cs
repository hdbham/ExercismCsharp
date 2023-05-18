using System;
using System.Text.RegularExpressions;

static class LogLine
{

    private static readonly string pattern = @"\[(\w+)\]:\s(.+)";

     public static string LogLevel(string logLine)
    {
        var match = Regex.Match(logLine, pattern); 
        return match.Groups[1].Value.ToLower();
    }
    
    public static string Message(string logLine)
    {
        var match = Regex.Match(logLine, pattern);
        return match.Groups[2].Value.Trim();
    }

    public static string Reformat(string logLine)
    {
        string trimmedLogLine = logLine.Trim();
        string message = Message(trimmedLogLine);
        string logLevel = LogLevel(trimmedLogLine);
        return $"{message} ({logLevel})";
    }
}
