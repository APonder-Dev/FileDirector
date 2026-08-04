namespace FileDirector.Infrastructure.Platform;

/// <summary>
/// Resolves the cross-platform, per-user application data locations FileDirector writes to:
/// the SQLite database, structured logs, and managed trash. Everything lives under one root
/// so it is easy to locate, back up, or wipe, and so tests can point it at an isolated temp
/// directory instead of the real user profile.
/// </summary>
public static class ApplicationPaths
{
    private const string ApplicationFolderName = "FileDirector";

    /// <summary>
    /// The root application data directory, e.g. %AppData%/FileDirector on Windows or
    /// ~/.local/share/FileDirector on Linux/macOS.
    /// </summary>
    public static string GetDefaultRoot() =>
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create),
            ApplicationFolderName);

    public static string GetLogsDirectory(string root) => Path.Combine(root, "logs");

    public static string GetDatabasePath(string root) => Path.Combine(root, "filedirector.db");

    public static string GetManagedTrashDirectory(string root) => Path.Combine(root, "trash");

    /// <summary>
    /// Ensures the root and its well-known subdirectories exist, creating them if necessary.
    /// </summary>
    public static void EnsureCreated(string root)
    {
        Directory.CreateDirectory(root);
        Directory.CreateDirectory(GetLogsDirectory(root));
        Directory.CreateDirectory(GetManagedTrashDirectory(root));
    }
}
