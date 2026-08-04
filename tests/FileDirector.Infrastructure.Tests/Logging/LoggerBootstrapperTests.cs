using FileDirector.Infrastructure.Logging;
using FluentAssertions;

namespace FileDirector.Infrastructure.Tests.Logging;

public class LoggerBootstrapperTests : IDisposable
{
    private readonly string _tempLogsDir = Path.Combine(Path.GetTempPath(), "FileDirectorTests_" + Guid.NewGuid().ToString("N"));

    [Fact]
    public void CreateLogger_writes_a_log_file_into_the_given_directory()
    {
        Directory.CreateDirectory(_tempLogsDir);

        using (var logger = LoggerBootstrapper.CreateLogger(_tempLogsDir))
        {
            logger.Information("smoke test entry");
        }

        Directory.GetFiles(_tempLogsDir, "filedirector-*.log").Should().NotBeEmpty();
    }

    [Fact]
    public void CreateLogger_throws_for_null_or_whitespace_directory()
    {
        var act = () => LoggerBootstrapper.CreateLogger(" ");

        act.Should().Throw<ArgumentException>();
    }

    public void Dispose()
    {
        if (Directory.Exists(_tempLogsDir))
        {
            Directory.Delete(_tempLogsDir, recursive: true);
        }
    }
}
