using FluentAssertions;

namespace FileDirector.Domain.Tests;

/// <summary>
/// Placeholder proving the test project is correctly wired to FileDirector.Domain.
/// Real coverage (entities, value objects, rule states) starts in Phase 2.
/// </summary>
public class AssemblyWiringTests
{
    [Fact]
    public void Domain_assembly_marker_is_reachable()
    {
        typeof(AssemblyMarker).Assembly.GetName().Name.Should().Be("FileDirector.Domain");
    }
}
