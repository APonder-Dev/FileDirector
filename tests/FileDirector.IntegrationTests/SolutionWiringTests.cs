using FileDirector.Infrastructure.Platform;
using FluentAssertions;

namespace FileDirector.IntegrationTests;

/// <summary>
/// Placeholder proving the Cli/Infrastructure/Application/Domain layers link together
/// end to end. Real end-to-end coverage begins with the initial vertical slice
/// (register directory -> scan -> preview -> approve -> move -> record -> roll back).
/// </summary>
public class SolutionWiringTests
{
    [Fact]
    public void Infrastructure_platform_paths_are_reachable_from_the_integration_project()
    {
        var root = ApplicationPaths.GetDefaultRoot();

        root.Should().NotBeNullOrWhiteSpace();
    }
}
