using FluentAssertions;

namespace FileDirector.Application.Tests;

/// <summary>
/// Placeholder proving the test project is correctly wired to FileDirector.Application.
/// Real coverage (rule evaluation, planning, execution orchestration) starts in Phase 3.
/// </summary>
public class AssemblyWiringTests
{
    [Fact]
    public void Application_assembly_marker_is_reachable()
    {
        typeof(AssemblyMarker).Assembly.GetName().Name.Should().Be("FileDirector.Application");
    }
}
