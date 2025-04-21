using System.Diagnostics;

namespace TurnBased2DGame;

/// <summary>
/// Provides static methods for writing log messages to the console and a log file.
/// </summary>
/// <remarks>
/// This class uses <see cref="System.Diagnostics.Trace"/> to support logging with log levels
/// like Information, Warning. Logs are written to both the terminal and 'game.log'.
/// </remarks>
public class Logger
{
    /// <summary>
    /// Provides the different log levels
    /// </summary>
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

    /// <summary>
    /// Creates the log message which is sent to the terminal and the .log file
    /// </summary>
    /// <param name="message">The message which needs to be logged</param>
    /// <param name="level">The log type, by default will be Information</param>
    public static void Log(string message, LogLevel level = LogLevel.Information)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string prefix = level.ToString().ToUpper();
        Trace.WriteLine($"[{timestamp}] [{prefix}] {message}");
    }
    
    /// <summary>
    /// Creating the log, by specifying Information as the log type.
    /// </summary>
    /// <param name="message">The message which needs to be logged</param>
    public static void Information(string message) => Log(message, LogLevel.Information);
    /// <summary>
    /// Creating the log, by specifying Warning as the log type.
    /// </summary>
    /// <param name="message">The message which needs to be logged</param>
    public static void Warning(string message) => Log(message, LogLevel.Warning);
    /// <summary>
    /// Creating the log, by specifying Error as the log type.
    /// </summary>
    /// <param name="message">The message which needs to be logged</param>
    public static void Error(string message) => Log(message, LogLevel.Error);
}