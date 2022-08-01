namespace Reloaded.Mod.Loader.Update.Interfaces;

/// <summary>
/// Represents a package that can be downloaded.
/// </summary>
public interface IDownloadablePackage : INotifyPropertyChanged
{
    /// <summary>
    /// Id of the mod to be downloaded.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Name of the mod to be downloaded.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The mod authors.
    /// </summary>
    public string Authors { get; }

    /// <summary>
    /// Short description of the mod, as seen in mod config menu.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Source of the package.
    /// </summary>
    public string Source { get; }

    /// <summary>
    /// Version of the mod to download.
    /// </summary>
    public NuGetVersion Version { get; }

    /// <summary>
    /// File size in bytes of the item to be downloaded.
    /// </summary>
    public long FileSize { get; }

    /// <summary>
    /// Provides a human readable readme file, in markdown format.
    /// </summary>
    public string? MarkdownReadme { get; }

    /// <summary>
    /// Long description of the mod.
    /// </summary>
    public string LongDescription => MarkdownReadme ?? Description;

    /// <summary>
    /// Provides a list of images for this package.
    /// </summary>
    public DownloadableImage[]? Images { get; set; }

    /// <summary>
    /// Downloads the package in question asynchronously.
    /// </summary>
    /// <param name="packageFolder">The folder containing all the packages.</param>
    /// <param name="progress">Provides progress reporting for the download operation.</param>
    /// <param name="token">Allows you to cancel the operation.</param>
    /// <returns>Folder where the package was downloaded.</returns>
    public Task<string> DownloadAsync(string packageFolder, IProgress<double>? progress, CancellationToken token = default);
}

/// <summary>
/// Represents an image that can be downloaded from the web for this package.
/// </summary>
public struct DownloadableImage
{
    /// <summary>
    /// Provides an URL to the image.
    /// </summary>
    public Uri Uri { get; set; }

    /// <summary>
    /// Caption to display under the image.
    /// </summary>
    public string? Caption { get; set; }

    /// <summary>
    /// Provides additional thumbnails for this image.
    /// </summary>
    public DownloadableImageThumbnail[]? Thumbnails { get; set; }
}

/// <summary>
/// Represents a thumbnail for downloadable image.
/// </summary>
public struct DownloadableImageThumbnail
{
    /// <summary>
    /// Represents a thumbnail for a downloadable image.
    /// </summary>
    /// <param name="uri">Full URI to the image.</param>
    /// <param name="widthHint">Hint about the width of the image.</param>
    public DownloadableImageThumbnail(Uri uri, short? widthHint = null)
    {
        Uri = uri;
        WidthHint = widthHint;
    }

    /// <summary>
    /// Provides an URL to the image.
    /// </summary>
    public Uri Uri { get; set; }

    /// <summary>
    /// Provides a hint regarding the width of an image.
    /// Used for picking images without downloading them.
    /// </summary>
    public short? WidthHint { get; set; }
}