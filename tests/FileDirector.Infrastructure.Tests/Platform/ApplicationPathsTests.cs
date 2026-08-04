using FileDirector.Infrastructure.Platform;
using FluentAssertions;

namespace FileDirector.Infrastructure.Tests.Platform;

public class ApplicationPathsTests : IDisposable
{
    private readonly string _tempRoot = Path.Combine(Path.GetTempPath(), "FileDirectorTests_" + Guid.NewGuid().ToString("N"));

    [Fact]
    public void EnsureCreated_creates_root_logs_and_trash_directories()
    {
        ApplicationPaths.EnsureCreated(_tempRoot);

        Directory.Exists(_tempRoot).Should().BeTrue();
        Directory.Exists(ApplicationPaths.GetLogsDirectory(_tempRoot)).Should().BeTrue();
        Directory.Exists(ApplicationPaths.GetManagedTrashDirectory(_tempRoot)).Should().BeTrue();
    }

    [Fact]
    public void GetDatabasePath_is_nested_under_the_given_root()
    {
        var dbPath = ApplicationPaths.GetDatabasePath(_tempRoot);

        dbPath.Should().StartWith(_tempRoot);
        dbPath.Should().EndWith("filedirector.db");
    }

    [Fact]
    public void GetDefaultRoot_ends_with_application_folder_name()
    {
        ApplicationPaths.GetDefaultRoot().Should().EndWith("FileDirector");
    }

    public void Dispose()
    {
        if (Directory.Exists(_tempRoot))
        {
            Directory.Delete(_tempRoot, recursive: true);
        }
    }
}
