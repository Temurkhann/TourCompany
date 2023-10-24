namespace ProtoolsStore.Domain.Configurations;

/// <summary>
/// Represents the parameters for pagination, including the page size and index.
/// </summary>
public class PaginationParams
{
    /// <summary>
    /// The maximum allowed page size.
    /// </summary>
    private const int MAX_SIZE = 10;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="PaginationParams"/> class with the default page size set to the maximum allowed size.
    /// </summary>
    private int _pageSize = MAX_SIZE;
    
    /// <summary>
    /// Gets or sets the page size. If the specified value exceeds the maximum allowed size, it is set to the maximum size.
    /// </summary>
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MAX_SIZE ? MAX_SIZE : value;
    }

    /// <summary>
    /// Gets or sets the page index.
    /// </summary>
    public int PageIndex { get; set; }
}