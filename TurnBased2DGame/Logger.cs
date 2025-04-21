using System.Diagnostics;

namespace TurnBased2DGame;

public class Logger
{
    public enum LogLevel
    {
        Information,
        Warning,
        Error
    }
    
    static Logger()
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.Listeners.Add(new TextWriterTraceListener("game.log"));
        Trace.AutoFlush = true;
    }

    public static void Log(string message, LogLevel level = LogLevel.Information)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string prefix = level.ToString().ToUpper();
        Trace.WriteLine($"[{timestamp}] [{prefix}] {message}");
    }
    
    public static void Information(string message) => Log(message, LogLevel.Information);
    public static void Warning(string message) => Log(message, LogLevel.Warning);
    public static void Error(string message) => Log(message, LogLevel.Error);
}