namespace ProtoolsStore.Services;

/// <summary>
/// Helper class providing access to environment-related paths and values.
/// </summary>
public static class EnvironmentHelper
{
    /// <summary>
    /// Gets or sets the web root path of the application.
    /// </summary>
    public static string? WebRootPath { get; set; }

    /// <summary>
    /// Gets the full attachment path by combining the web root path and the "images" folder.
    /// </summary>
    public static string AttachmentPath => Path.Combine(WebRootPath!, Attachment);

    /// <summary>
    /// Gets the relative attachment folder path.
    /// </summary>
    public static string Attachment => "images";

    /// <summary>
    /// Gets the full file path by combining the web root path and the "file" folder.
    /// </summary>
    public static string FilePath => Path.Combine(WebRootPath, File);

    /// <summary>
    /// Gets the relative file folder path.
    /// </summary>
    public static string File => "file";
}
