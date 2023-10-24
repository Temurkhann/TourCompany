namespace ProtoolsStore.Domain.Configurations;

/// <summary>
/// App settings connection configuration base deserializer model
/// </summary>
public class ConnectionStrings
{
    /// <summary>
    /// Database Connection String
    /// </summary>
    public string? DefaultConnectionString { get; set; } = null!;
}