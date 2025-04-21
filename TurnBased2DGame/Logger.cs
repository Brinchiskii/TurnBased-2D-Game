using System.Diagnostics;

namespace TurnBased2DGame;

public class Logger
{
    static Logger()
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.Listeners.Add(new TextWriterTraceListener("game.log"));
        Trace.AutoFlush = true;
    }

    public static void Log(string message)
    {
        Trace.WriteLine($"[{DateTime.Now:g}] {message}");
    }
}