using FileDirector.Infrastructure.Logging;
using FileDirector.Infrastructure.Platform;
using Serilog;
using Spectre.Console;

var appRoot = ApplicationPaths.GetDefaultRoot();
ApplicationPaths.EnsureCreated(appRoot);

using var logger = LoggerBootstrapper.CreateLogger(ApplicationPaths.GetLogsDirectory(appRoot));
Log.Logger = logger;

try
{
    AnsiConsole.MarkupLine("[bold]FileDirector[/] — configurable file organization and automation utility");
    AnsiConsole.MarkupLine("[grey]Command set not yet implemented — repository foundation phase.[/]");
    logger.Information("FileDirector CLI started. AppRoot={AppRoot}", appRoot);

    // Command wiring (scan, preview, apply, duplicates, rules, history, rollback, monitor,
    // health) lands in Phase 7 once the rule engine and operation planner exist.
    return 0;
}
catch (Exception ex)
{
    logger.Fatal(ex, "FileDirector CLI terminated unexpectedly");
    AnsiConsole.MarkupLine("[red]A fatal error occurred. See the log file for details.[/]");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}
