using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace FileDirector.Infrastructure.Logging;

/// <summary>
/// Builds the application's Serilog pipeline: structured console output plus a rolling,
/// size-limited daily log file. File contents are never logged here — callers must pass
/// only sanitized path context, correlation IDs, and operation identifiers as properties.
/// </summary>
public static class LoggerBootstrapper
{
    private const string OutputTemplate =
        "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}";

    /// <summary>
    /// Creates a configured, ready-to-use Serilog logger. <paramref name="logsDirectory"/> must
    /// already exist or be creatable by the caller (see <see cref="Platform.ApplicationPaths"/>).
    /// </summary>
    public static Logger CreateLogger(string logsDirectory, LogEventLevel minimumLevel = LogEventLevel.Information)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(logsDirectory);

        return new LoggerConfiguration()
            .MinimumLevel.Is(minimumLevel)
            .Enrich.FromLogContext()
            .Enrich.WithProperty("Application", "FileDirector")
            .WriteTo.Console(outputTemplate: OutputTemplate)
            .WriteTo.File(
                Path.Combine(logsDirectory, "filedirector-.log"),
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 31,
                fileSizeLimitBytes: 10 * 1024 * 1024,
                rollOnFileSizeLimit: true,
                outputTemplate: OutputTemplate)
            .CreateLogger();
    }
}
